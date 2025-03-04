/*
  LICENSE
  -------
  Copyright (C) 2007-2010 Ray Molenkamp

  This source code is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this source code or the software it produces.

  Permission is granted to anyone to use this source code for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this source code must not be misrepresented; you must not
     claim that you wrote the original source code.  If you use this source code
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original source code.
  3. This notice may not be removed or altered from any source distribution.
*/
/* Updated by John de Jong (2020/04/02) */

using System;
using System.Runtime.InteropServices;
using CoreAudio.Interfaces;

namespace CoreAudio {
    internal class AudioSessionEvents : IAudioSessionEvents {
        _IAudioSessionControl parent;

        internal AudioSessionEvents(_IAudioSessionControl parent) {
            this.parent = parent;
        }

        [PreserveSig]
        public int OnDisplayNameChanged([MarshalAs(UnmanagedType.LPWStr)] string NewDisplayName, ref Guid EventContext) {
            parent.FireDisplayNameChanged(NewDisplayName, EventContext);
            return 0;
        }

        [PreserveSig]
        public int OnIconPathChanged([MarshalAs(UnmanagedType.LPWStr)] string NewIconPath, ref Guid EventContext) {
            parent.FireOnIconPathChanged(NewIconPath, EventContext);
            return 0;
        }

        [PreserveSig]
        public int OnSimpleVolumeChanged(float NewVolume, bool newMute, ref Guid EventContext) {
            parent.FireSimpleVolumeChanged(NewVolume, newMute, EventContext);
            return 0;
        }

        [PreserveSig]
        public int OnChannelVolumeChanged(uint ChannelCount, IntPtr NewChannelVolumeArray, uint ChangedChannel, ref Guid EventContext) {
            parent.FireChannelVolumeChanged(ChannelCount, NewChannelVolumeArray, ChangedChannel, EventContext);
            return 0;
        }

        [PreserveSig]
        public int OnGroupingParamChanged(ref Guid NewGroupingParam, ref Guid EventContext) {
            return 0;
        }

        [PreserveSig]
        public int OnStateChanged(AudioSessionState NewState) {
            parent.FireStateChanged(NewState);
            return 0;
        }

        [PreserveSig]
        public int OnSessionDisconnected(AudioSessionDisconnectReason DisconnectReason) {
            return 0;
        }
    }
}
