using Fiver.Security.AuthServer.Client.Models.Home;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Fiver.Security.AuthServer.Client.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> MoviesAsync()
        {
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:5001/api/address/1015");
            return Json(content); ;
            //var model = JsonConvert.DeserializeObject<List<MovieViewModel>>(content);


            //var disco = DiscoveryClient.GetAsync("https://localhost:44350/").Result;

            //// request token
            //var tokenClient = new TokenClient(disco.TokenEndpoint, "fiver_auth_client_ro", "secret");
            //var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync("vova4@vova.com", "fasdfsdafASD123..", "fiver_auth_api").Result;

            ////Console.WriteLine(tokenResponse.Json);

            //// call api
            //var client = new HttpClient();
            //client.SetBearerToken(tokenResponse.AccessToken);

            //var response = client.GetAsync("http://localhost:5001/api/address/1015").Result;
            //var content = response.Content.ReadAsStringAsync().Result;

            ////var model = JsonConvert.DeserializeObject<List<MovieViewModel>>(content);
            
            //return Json(content); ;
        }

        public IActionResult Claims()
        {
            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
