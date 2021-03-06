﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using NuGetGallery.Services.Authentication;

namespace NuGetGallery.Infrastructure.Authentication
{
    public class CredentialBuilder : ICredentialBuilder
    {
        public const string LatestPasswordType = CredentialTypes.Password.V3;

        public Credential CreatePasswordCredential(string plaintextPassword)
        {
            return new Credential(
                LatestPasswordType,
                V3Hasher.GenerateHash(plaintextPassword));
        }

        public Credential CreateApiKey(TimeSpan? expiration)
        {
            return new Credential(
               CredentialTypes.ApiKey.V2,
               Guid.NewGuid().ToString().ToLowerInvariant(),
               expiration: expiration);
        }

        public Credential CreateExternalCredential(string issuer, string value, string identity)
        {
            return new Credential(CredentialTypes.ExternalPrefix + issuer, value)
            {
                Identity = identity
            };
        }
    }
}