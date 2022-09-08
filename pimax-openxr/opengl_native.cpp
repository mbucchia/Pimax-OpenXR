// MIT License
//
// Copyright(c) 2022 Matthieu Bucchianeri
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this softwareand associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and /or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright noticeand this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

#include "pch.h"

#include "log.h"
#include "runtime.h"
#include "utils.h"

// Implements native support to submit swapchains to PVR.
// Implements the necessary support for the XR_KHR_opengl_enable extension:
// https://www.khronos.org/registry/OpenXR/specs/1.0/html/xrspec.html#XR_KHR_opengl_enable

namespace pimax_openxr {
    using namespace pimax_openxr::log;
    using namespace pimax_openxr::utils;

    // https://www.khronos.org/registry/OpenXR/specs/1.0/html/xrspec.html#xrGetOpenGLGraphicsRequirementsKHR
    XrResult OpenXrRuntime::xrGetOpenGLGraphicsRequirementsKHR(XrInstance instance,
                                                               XrSystemId systemId,
                                                               XrGraphicsRequirementsOpenGLKHR* graphicsRequirements) {
        if (graphicsRequirements->type != XR_TYPE_GRAPHICS_REQUIREMENTS_OPENGL_KHR) {
            return XR_ERROR_VALIDATION_FAILURE;
        }

        TraceLoggingWrite(g_traceProvider,
                          "xrGetOpenGLGraphicsRequirementsKHR",
                          TLXArg(instance, "Instance"),
                          TLArg((int)systemId, "SystemId"));

        if (!m_instanceCreated || instance != (XrInstance)1) {
            return XR_ERROR_HANDLE_INVALID;
        }

        if (!m_systemCreated || systemId != (XrSystemId)1) {
            return XR_ERROR_SYSTEM_INVALID;
        }

        if (!m_isOpenGLSupported) {
            return XR_ERROR_FUNCTION_UNSUPPORTED;
        }

        // Get the display device LUID.
        fillDisplayDeviceInfo();

        // Framebuffer support (that we use for texture array copy) requires OpenGL 3.0.
        graphicsRequirements->minApiVersionSupported = XR_MAKE_VERSION(3, 0, 0);
        graphicsRequirements->maxApiVersionSupported = XR_MAKE_VERSION(5, 0, 0);

        TraceLoggingWrite(
            g_traceProvider,
            "xrGetOpenGLGraphicsRequirementsKHR",
            TLArg(xr::ToString(graphicsRequirements->minApiVersionSupported).c_str(), "MinApiVersionSupported"),
            TLArg(xr::ToString(graphicsRequirements->maxApiVersionSupported).c_str(), "MaxApiVersionSupported"));

        m_graphicsRequirementQueried = true;

        return XR_SUCCESS;
    }

    // Initialize all the resources needed for OpenGL support, both on the API frontend and also the runtime/PVR
    // backend.
    XrResult OpenXrRuntime::initializeOpenGL(const XrGraphicsBindingOpenGLWin32KHR& glBindings) {
        // Gather function pointers for the OpenGL extensions we are going to use.
        initializeOpenGLDispatch();

        m_glContext.glDC = glBindings.hDC;
        m_glContext.glRC = glBindings.hGLRC;
        m_glContext.valid = true;

        GlContextSwitch context(m_glContext);

        // Check that this is the correct adapter for the HMD.
        LUID adapterLuid{};
        m_glDispatch.glGetUnsignedBytevEXT(GL_DEVICE_LUID_EXT, (GLubyte*)&adapterLuid);
        if (memcmp(&adapterLuid, &m_adapterLuid, sizeof(LUID))) {
            return XR_ERROR_GRAPHICS_DEVICE_INVALID;
        }

        ComPtr<IDXGIFactory1> dxgiFactory;
        CHECK_HRCMD(CreateDXGIFactory1(IID_PPV_ARGS(dxgiFactory.ReleaseAndGetAddressOf())));

        ComPtr<IDXGIAdapter1> dxgiAdapter;
        for (UINT adapterIndex = 0;; adapterIndex++) {
            // EnumAdapters1 will fail with DXGI_ERROR_NOT_FOUND when there are no more adapters to
            // enumerate.
            CHECK_HRCMD(dxgiFactory->EnumAdapters1(adapterIndex, dxgiAdapter.ReleaseAndGetAddressOf()));

            DXGI_ADAPTER_DESC1 desc;
            CHECK_HRCMD(dxgiAdapter->GetDesc1(&desc));
            if (!memcmp(&desc.AdapterLuid, &m_adapterLuid, sizeof(LUID))) {
                std::string deviceName;
                const std::wstring wadapterDescription(desc.Description);
                std::transform(wadapterDescription.begin(),
                               wadapterDescription.end(),
                               std::back_inserter(deviceName),
                               [](wchar_t c) { return (char)c; });

                TraceLoggingWrite(g_traceProvider,
                                  "xrCreateSession",
                                  TLArg("OpenGL", "Api"),
                                  TLArg(deviceName.c_str(), "AdapterName"));
                Log("Using OpenGL on adapter: %s\n", deviceName.c_str());
                break;
            }
        }

        m_glDispatch.glGenFramebuffers(1, &m_glCopyFbo);

        return XR_SUCCESS;
    }

    // Initialize the function pointers for the OpenGL extensions.
    void OpenXrRuntime::initializeOpenGLDispatch() {
#define GL_GET_PTR(fun)                                                                                                \
    m_glDispatch.fun = reinterpret_cast<decltype(m_glDispatch.fun)>(wglGetProcAddress(#fun));                          \
    CHECK_MSG(m_glDispatch.fun, "OpenGL driver does not support " #fun);

        GL_GET_PTR(glGetUnsignedBytevEXT);
        GL_GET_PTR(glGenFramebuffers);
        GL_GET_PTR(glDeleteFramebuffers);
        GL_GET_PTR(glBindFramebuffer);
        GL_GET_PTR(glFramebufferTexture2D);
        GL_GET_PTR(glFramebufferTexture3D);
        GL_GET_PTR(glCopyTextureSubImage2D);

#undef GL_GET_PTR
    }

    void OpenXrRuntime::cleanupOpenGL() {
        if (m_glContext.valid) {
            flushOpenGLContext();

            m_glDispatch.glDeleteFramebuffers(1, &m_glCopyFbo);

            m_glContext.valid = false;
        }
    }

    bool OpenXrRuntime::isOpenGLSession() const {
        return m_glContext.valid;
    }

    // Retrieve the swapchain images for the application to use.
    XrResult OpenXrRuntime::getSwapchainImagesOpenGL(Swapchain& xrSwapchain,
                                                     XrSwapchainImageOpenGLKHR* glImages,
                                                     uint32_t count) {
        GlContextSwitch context(m_glContext);

        // Detect whether this is the first call for this swapchain.
        const bool initialized = !xrSwapchain.glSlices[0].empty();

        auto traceTexture = [](GLuint texture, const char* type) {
            TraceLoggingWrite(
                g_traceProvider, "xrEnumerateSwapchainImages", TLArg("OpenGL", "Api"), TLArg(type, "Type"));
        };

        // Query the textures for the swapchain.
        for (uint32_t i = 0; i < count; i++) {
            if (glImages[i].type != XR_TYPE_SWAPCHAIN_IMAGE_OPENGL_KHR) {
                return XR_ERROR_VALIDATION_FAILURE;
            }

            if (!initialized) {
                GLuint swapchainTexture;
                CHECK_PVRCMD(
                    pvr_getTextureSwapChainBufferGL(m_pvrSession, xrSwapchain.pvrSwapchain[0], i, &swapchainTexture));

                xrSwapchain.glSlices[0].push_back(swapchainTexture);
                if (i == 0) {
                    traceTexture(swapchainTexture, "PVR");
                }
            }

            glImages[i].image = xrSwapchain.glSlices[0][i];

            if (i == 0) {
                traceTexture(glImages[0].image, "Runtime");
            }

            TraceLoggingWrite(g_traceProvider,
                              "xrEnumerateSwapchainImages",
                              TLArg("OpenGL", "Api"),
                              TLArg(glImages[i].image, "Texture"));
        }

        return XR_SUCCESS;
    }

    // Prepare a PVR swapchain to be used by PVR.
    void OpenXrRuntime::prepareAndCommitSwapchainImageOpenGL(
        Swapchain& xrSwapchain, uint32_t slice, std::set<std::pair<pvrTextureSwapChain, uint32_t>>& committed) const {
        // Context is saved by the caller for performance.

        // If the texture was already committed, do nothing.
        if (committed.count(std::make_pair(xrSwapchain.pvrSwapchain[0], slice))) {
            return;
        }

        // Circumvent some of PVR's limitations:
        // - For texture arrays, we must do a copy to slice 0 into another swapchain.
        if (slice > 0) {
            // Lazily create a second swapchain for this slice of the array.
            if (!xrSwapchain.pvrSwapchain[slice]) {
                auto desc = xrSwapchain.pvrDesc;
                desc.ArraySize = 1;
                CHECK_PVRCMD(pvr_createTextureSwapChainGL(m_pvrSession, &desc, &xrSwapchain.pvrSwapchain[slice]));

                int count = -1;
                CHECK_PVRCMD(pvr_getTextureSwapChainLength(m_pvrSession, xrSwapchain.pvrSwapchain[slice], &count));
                if (count != xrSwapchain.glSlices[0].size()) {
                    throw std::runtime_error("Swapchain image count mismatch");
                }

                // Query the textures for the swapchain.
                for (int i = 0; i < count; i++) {
                    GLuint texture;
                    CHECK_PVRCMD(
                        pvr_getTextureSwapChainBufferGL(m_pvrSession, xrSwapchain.pvrSwapchain[slice], i, &texture));

                    xrSwapchain.glSlices[slice].push_back(texture);
                }
            }

            // Copy or convert into the PVR swapchain.
            int pvrDestIndex = -1;
            CHECK_PVRCMD(
                pvr_getTextureSwapChainCurrentIndex(m_pvrSession, xrSwapchain.pvrSwapchain[slice], &pvrDestIndex));

            int pvrSourceIndex = xrSwapchain.pvrLastReleasedIndex;

            m_glDispatch.glBindFramebuffer(GL_FRAMEBUFFER, m_glCopyFbo);
            m_glDispatch.glFramebufferTexture3D(GL_FRAMEBUFFER,
                                                GL_COLOR_ATTACHMENT0,
                                                GL_TEXTURE_2D_ARRAY,
                                                xrSwapchain.glSlices[0][pvrSourceIndex],
                                                0,
                                                slice);
            m_glDispatch.glCopyTextureSubImage2D(xrSwapchain.glSlices[0][pvrDestIndex],
                                                 0,
                                                 0,
                                                 0,
                                                 0,
                                                 0,
                                                 xrSwapchain.pvrDesc.Width,
                                                 xrSwapchain.pvrDesc.Height);
            m_glDispatch.glBindFramebuffer(GL_FRAMEBUFFER, 0);
        } else {
            // The app may render to certain swapchains (eg: quad layers) at a lower frame rate. We must perform a copy
            // to the current PVR swapchain image.
            int pvrCurrentIndex = -1;
            CHECK_PVRCMD(
                pvr_getTextureSwapChainCurrentIndex(m_pvrSession, xrSwapchain.pvrSwapchain[0], &pvrCurrentIndex));
            if (pvrCurrentIndex != xrSwapchain.pvrLastReleasedIndex) {
                m_glDispatch.glBindFramebuffer(GL_FRAMEBUFFER, m_glCopyFbo);
                m_glDispatch.glFramebufferTexture2D(GL_FRAMEBUFFER,
                                                    GL_COLOR_ATTACHMENT0,
                                                    GL_TEXTURE_2D,
                                                    xrSwapchain.glSlices[0][xrSwapchain.pvrLastReleasedIndex],
                                                    0);
                m_glDispatch.glCopyTextureSubImage2D(xrSwapchain.glSlices[0][pvrCurrentIndex],
                                                     0,
                                                     0,
                                                     0,
                                                     0,
                                                     0,
                                                     xrSwapchain.pvrDesc.Width,
                                                     xrSwapchain.pvrDesc.Height);
                m_glDispatch.glBindFramebuffer(GL_FRAMEBUFFER, 0);
            }
        }

        // Commit the texture to PVR.
        CHECK_PVRCMD(pvr_commitTextureSwapChain(m_pvrSession, xrSwapchain.pvrSwapchain[slice]));
        committed.insert(std::make_pair(xrSwapchain.pvrSwapchain[0], slice));
    }

    // Flush any pending work.
    void OpenXrRuntime::flushOpenGLContext() {
        GlContextSwitch context(m_glContext);

        glFinish();
    }

} // namespace pimax_openxr
