// MIT License
//
// Copyright(c) 2022-2023 Matthieu Bucchianeri
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

using namespace pimax_openxr::utils;

struct RuntimeStatus {
    bool valid;

    float refreshRate;
    uint32_t resolutionWidth;
    uint32_t resolutionHeight;
    uint8_t fovLevel;
    float fov;
    float floorHeight;
    bool useParallelProjection;
    bool useSmartSmoothing;
    float fps;
};

extern "C" __declspec(dllexport) void WINAPI getRuntimeStatus(RuntimeStatus* status) {
    pimax_openxr::log::Log("Hello\n");

    pvrEnvHandle pvr;
    CHECK_PVRCMD(pvr_initialise(&pvr));

    pvrSessionHandle pvrSession;
    CHECK_PVRCMD(pvr_createSession(pvr, &pvrSession));

    // Ensure there is no stale parallel projection settings.
    CHECK_PVRCMD(pvr_setIntConfig(pvrSession, "view_rotation_fix", 0));

    pvrDisplayInfo displayInfo{};
    CHECK_PVRCMD(pvr_getEyeDisplayInfo(pvrSession, pvrEye_Left, &displayInfo));

    pvrEyeRenderInfo eyeInfo[xr::StereoView::Count];
    CHECK_PVRCMD(pvr_getEyeRenderInfo(pvrSession, pvrEye_Left, &eyeInfo[xr::StereoView::Left]));
    CHECK_PVRCMD(pvr_getEyeRenderInfo(pvrSession, pvrEye_Right, &eyeInfo[xr::StereoView::Right]));
    const auto cantingAngle = PVR::Quatf{eyeInfo[xr::StereoView::Left].HmdToEyePose.Orientation}.Angle(
                                  eyeInfo[xr::StereoView::Right].HmdToEyePose.Orientation) /
                              2.f;
    const auto fov = PVR::RadToDegree(atan(eyeInfo[xr::StereoView::Left].Fov.LeftTan) +
                                      atan(eyeInfo[xr::StereoView::Right].Fov.RightTan) + cantingAngle * 2.f);
    const auto useParallelProjection =
        cantingAngle > 0.0001f &&
        RegGetDword(HKEY_LOCAL_MACHINE, "SOFTWARE\\PimaxXR", "force_parallel_projection_state")
            .value_or(!pvr_getIntConfig(pvrSession, "steamvr_use_native_fov", 0));

    if (useParallelProjection) {
        // Per Pimax, we must set this value for parallel projection to work properly.
        CHECK_PVRCMD(pvr_setIntConfig(pvrSession, "view_rotation_fix", 1));

        // Update eye info to account for parallel projection.
        CHECK_PVRCMD(pvr_getEyeRenderInfo(pvrSession, pvrEye_Left, &eyeInfo[xr::StereoView::Left]));
        CHECK_PVRCMD(pvr_getEyeRenderInfo(pvrSession, pvrEye_Right, &eyeInfo[xr::StereoView::Right]));
    }

    const pvrFovPort fovForResolution = eyeInfo[xr::StereoView::Left].Fov;

    pvrSizei viewportSize;
    CHECK_PVRCMD(pvr_getFovTextureSize(pvrSession, pvrEye_Left, fovForResolution, 1.f, &viewportSize));

    status->refreshRate = displayInfo.refresh_rate;
    status->resolutionWidth = viewportSize.w;
    status->resolutionHeight = viewportSize.h;
    status->fovLevel = pvr_getIntConfig(pvrSession, "fov_level", 1);
    status->fov = fov;
    status->floorHeight = pvr_getFloatConfig(pvrSession, CONFIG_KEY_EYE_HEIGHT, 0.f);
    status->useParallelProjection = useParallelProjection;
    status->useSmartSmoothing = pvr_getIntConfig(pvrSession, "dbg_asw_enable", 0);
    status->fps = pvr_getFloatConfig(pvrSession, "client_fps", 0);

    status->valid = true;

    pvr_destroySession(pvrSession);
    pvr_shutdown(pvr);
}
