using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System;

namespace Mentorship.CleaningService.ClientConsole
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            // discover endpoints from the metadata by calling Auth server hosted on 5000 port
            try
            {
                // discover endpoints from metadata
                var disco = DiscoveryClient.GetAsync("https://localhost:44350").Result;

                // request token
                var tokenClient = new TokenClient(disco.TokenEndpoint, "fiver_auth_client_ro", "secret");
                var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync("vova4@vova.com", "fasdfsdafASD123..", "fiver_auth_api").Result;
                //var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync("james", "password", "fiver_auth_api").Result;

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    return;
                }
                Console.WriteLine (tokenResponse.AccessToken);
                //Console.WriteLine(tokenResponse.Json);

                // call api
                var client = new HttpClient();
                client.SetBearerToken(tokenResponse.AccessToken);

                var response = client.GetAsync("http://localhost:5001/api/address/1015").Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(JArray.Parse(content));
                    Console.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
