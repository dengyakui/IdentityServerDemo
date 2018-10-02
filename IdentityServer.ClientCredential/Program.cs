using IdentityModel;
using IdentityModel.Client;
using System;
using System.Net.Http;
using IdentityModel.Jwk;
namespace IdentityServer.ClientCredential
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            DiscoveryClient discoveryClient = new DiscoveryClient("http://localhost:5000");
            DiscoveryResponse discoveryResponse = await discoveryClient.GetAsync();
            TokenClient tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, "client", "secret");
            TokenResponse tokenResponse = await tokenClient.RequestClientCredentialsAsync("api");
            Console.WriteLine(tokenResponse.AccessToken);

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            var response = await httpClient.GetStringAsync("http://localhost:5001/api/values");
            Console.WriteLine(response);

        }
    }
}
