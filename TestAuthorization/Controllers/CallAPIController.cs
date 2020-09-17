using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TestAuthorization.Model;

namespace TestAuthorization.Controllers
{
    public class CallAPIController : Controller
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

            return View("Reservation", linkList);
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

        // POST: CallAPIController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CallAPIController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CallAPIController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CallAPIController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CallAPIController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
