// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http3
{
    internal class Http3PeerSettings
    {
        // Note these are protocol defaults, not Kestrel defaults.
        public const uint DefaultHeaderTableSize = 0;
        public const uint DefaultMaxRequestHeaderFieldSize = uint.MaxValue;

        public uint HeaderTableSize { get; internal set; }
        public uint MaxRequestHeaderFieldSize { get; internal set; }

        // Gets the settings that are different from the protocol defaults (as opposed to the server defaults).
        internal List<Http3PeerSetting> GetNonProtocolDefaults()
        {
            var list = new List<Http3PeerSetting>(1);

            if (HeaderTableSize != DefaultHeaderTableSize)
            {
                list.Add(new Http3PeerSetting(Http3SettingType.QPackMaxTableCapacity, HeaderTableSize));
            }

            if (MaxRequestHeaderFieldSize != DefaultMaxRequestHeaderFieldSize)
            {
                list.Add(new Http3PeerSetting(Http3SettingType.MaxHeaderListSize, MaxRequestHeaderFieldSize));
            }

            return list;
        }
    }
}
