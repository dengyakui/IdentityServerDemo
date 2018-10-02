using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Center
{
    public class Config
    {
        public static List<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api","My Api")
            };
        }

        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client{
                    ClientId = "client",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = { GrantType.ClientCredentials,},
                    AllowedScopes =
                    {
                        "api"
                    }
                },
                new Client
                {
                    ClientId = "pwdclient",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes =
                    {
                        GrantType.ResourceOwnerPassword
                    },
                    AllowedScopes =
                    {
                        "api"
                    }
                }
        };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser{SubjectId = "1", Username = "jesse", Password = "123456"}
            };
        }
    }
}
