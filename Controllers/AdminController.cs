using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdminMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace AdminMVC.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetRecipe()

        {
 
            using (var client = new HttpClient())
            {
                string Baseurl = "https://localhost:44349/";
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<RecipeClass> rc = new List<RecipeClass>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44349/api/Recipes"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        rc = JsonConvert.DeserializeObject<List<RecipeClass>>(apiResponse);
                    }
                }

                return View(rc);
            }
        }

            public ActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddRecipe(RecipeClass r)
        {
            RecipeClass rc = new RecipeClass();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44349/api/Recipes/add", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rc = JsonConvert.DeserializeObject<RecipeClass>(apiResponse);
                }
            }
            return RedirectToAction("GetRecipe");
        }


        [HttpGet]
        public async Task<ActionResult> DeleteRecipe(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44349/api/Recipes/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetRecipe");
        }

    }
}
