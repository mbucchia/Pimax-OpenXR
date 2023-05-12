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

// Implements the necessary support for the XR_HTCX_vive_tracker_interaction extension:
// https://www.khronos.org/registry/OpenXR/specs/1.0/html/xrspec.html#XR_HTCX_vive_tracker_interaction

namespace pimax_openxr {

    using namespace pimax_openxr::log;
    using namespace pimax_openxr::utils;

    // https://www.khronos.org/registry/OpenXR/specs/1.0/html/xrspec.html#xrEnumerateViveTrackerPathsHTCX
    XrResult OpenXrRuntime::xrEnumerateViveTrackerPathsHTCX(XrInstance instance,
                                                            uint32_t pathCapacityInput,
                                                            uint32_t* pathCountOutput,
                                                            XrViveTrackerPathsHTCX* paths) {
        TraceLoggingWrite(g_traceProvider,
                          "xrEnumerateViveTrackerPathsHTCX",
                          TLXArg(instance, "Instance"),
                          TLArg(pathCapacityInput, "PathCapacityInput"));

        if (pathCapacityInput && pathCapacityInput < m_trackers.size()) {
            return XR_ERROR_SIZE_INSUFFICIENT;
        }

        *pathCountOutput = (uint32_t)m_trackers.size();
        TraceLoggingWrite(
            g_traceProvider, "xrEnumerateViveTrackerPathsHTCX", TLArg(*pathCountOutput, "PathCountOutput"));

        if (pathCapacityInput && paths) {
            uint32_t i = 0;
            for (const auto& tracker : m_trackers) {
                if (paths[i].type != XR_TYPE_VIVE_TRACKER_PATHS_HTCX) {
                    return XR_ERROR_VALIDATION_FAILURE;
                }

                const auto trackerSerial = tracker.first;
                const std::string persistentPath = "/user/vive_tracker_htcx/serial/" + trackerSerial;
                const std::string rolePath = getTrackerRolePath(trackerSerial);
                CHECK_XRCMD(xrStringToPath(XR_NULL_HANDLE, persistentPath.c_str(), &paths[i].persistentPath));
                if (!rolePath.empty()) {
                    CHECK_XRCMD(xrStringToPath(XR_NULL_HANDLE, rolePath.c_str(), &paths[i].rolePath));
                } else {
                    paths[i].rolePath = XR_NULL_PATH;
                }
                TraceLoggingWrite(g_traceProvider,
                                  "xrEnumerateViveTrackerPathsHTCX",
                                  TLArg(paths[i].persistentPath, "PersistentPath"),
                                  TLArg(paths[i].rolePath, "RolePath"),
                                  TLArg(persistentPath.c_str(), "PersistentPath"),
                                  TLArg(rolePath.c_str(), "RolePath"));
                i++;
            }
        }

        return XR_SUCCESS;
    }

    // Populate the mappings between role and serial number.
    void OpenXrRuntime::initializeTrackerRoleTable() {
        const auto addTracker = [&](const std::string& role, const std::optional<std::string>& serial) {
            if (serial) {
                m_trackersRoleToSerial.insert_or_assign(role, serial.value());
                m_trackersSerialToRole.insert_or_assign(serial.value(), role);
            }
        };

        const std::string roles[] = {"handheld_object",
                                     "left_foot",
                                     "right_foot",
                                     "left_shoulder",
                                     "right_shoulder",
                                     "left_elbow",
                                     "right_elbow",
                                     "left_knee",
                                     "right_knee",
                                     "waist",
                                     "chest",
                                     "camera",
                                     "keyboard"};
        for (const std::string& role : roles) {
            addTracker(role, RegGetString(HKEY_LOCAL_MACHINE, RegPrefix, "tracker_" + role));
        }
    }

    // Get the index of a tracker from either a serial or role path.
    int OpenXrRuntime::getTrackerIndex(const std::string& path) const {
        std::string serial;
        if (startsWith(path, "/user/vive_tracker_htcx/serial/")) {
            serial = path.substr(31);
        } else if (startsWith(path, "/user/vive_tracker_htcx/role/")) {
            const std::string role = path.substr(29);

            const auto& cit = m_trackersRoleToSerial.find(role);
            if (cit != m_trackersRoleToSerial.cend()) {
                serial = cit->second;
            }
        }

        if (!serial.empty()) {
            std::unique_lock lock(m_trackersLock);

            const auto& cit2 = m_trackers.find(serial);
            if (cit2 != m_trackers.cend()) {
                return cit2->second;
            }
        }

        return -1;
    }

    // Form a role path from a tracker's serial.
    std::string OpenXrRuntime::getTrackerRolePath(const std::string& serial) const {
        const auto& cit = m_trackersSerialToRole.find(serial);
        if (cit == m_trackersSerialToRole.cend()) {
            return "";
        }

        return "/user/vive_tracker_htcx/role/" + cit->second;
    }

} // namespace pimax_openxr
