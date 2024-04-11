﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Microsoft.Security.Utilities
{
    internal class SecretScanningSampleToken : RegexPattern
    {
        public const string AadClientAppLegacyCredentials = nameof(AadClientAppLegacyCredentials);


        /// <summary>
        /// Detect 32-character Azure Active Directory client application legacy credentials.
        /// The generated key is a 32-character string that contains alphanumeric characters
        /// as well as symbols from the set: .=\-:[_@\*]+?
        /// </summary>

        public SecretScanningSampleToken()
        {
            Id = "SEC101/565";
            Name = nameof(SecretScanningSampleToken);
            DetectionMetadata = DetectionMetadata.FixedSignature | DetectionMetadata.HighEntropy;
            Pattern = @$"{WellKnownRegexPatterns.PrefixBase62}(?P<secret>secret_scanning_ab85fc6f8d7638cf1c11da812da308d43_[0-9A-Za-z]{{5}}){WellKnownRegexPatterns.SuffixBase62}";
        }

        public override IEnumerable<string> GenerateTestExamples()
        {
            yield return $"secret_scanning_ab85fc6f8d7638cf1c11da812da308d43_{WellKnownRegexPatterns.RandomBase62(5)}";
        }
    }
}