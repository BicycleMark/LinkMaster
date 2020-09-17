using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LinkListTester.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LinkListTester.Controllers
{
    public class CallApiController : Controller
    {
        
      
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            if ((username != "Secret") || (password != "Secret"))
                return View((object)"Wrong Username or Password");

            var tokenString = GenerateJSONWebToken();
            List<Link> linkList = new List<Link>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
                using (var response = await httpClient.GetAsync("https://localhost:44366/Links"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    linkList = JsonConvert.DeserializeObject<List<Link>>(apiResponse);
                }
            }

            return View("Link", linkList);
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BicycleMarkLivesIn2020!"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://www.bicycle-mark.com",
                audience: "https://www.bicycle-mark.com",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       
    }
}
