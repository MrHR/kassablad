// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Kassablad.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("api1", "Kassablad.api")
            };
        
        public static IEnumerable<Client> Clients =>
            new List<Client>
            { 
                //machine to machine client
                new Client
                {
                    ClientId = "client",

                    //no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    //secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    //scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                //Javascript client
                new Client
                {
                    ClientId = "front_02",
                    ClientName = "Kassablad.front_02",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris =           { "http://localhost:3210/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:3210/kassablad.html" },
                    AllowedCorsOrigins =     { "http://localhost:3210" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                },
                //Vue client
                new Client
                {
                    ClientId = "ant-vue",
                    ClientName = "kassablad.ant-vue",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris =           { "https://localhost:3000/callback" },
                    PostLogoutRedirectUris = { "https://localhost:3000/kassablad" },
                    AllowedCorsOrigins =     { "https://localhost:3000" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
            };
        
    }
}