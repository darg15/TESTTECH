using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Test.DTO;

namespace Test.Controllers
{
    public class CardController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CardController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient.CreateClient("Servicio");
        }

        public async Task<IActionResult> Index()
        {

            var respuesta = await _httpClient.GetAsync("User/GetUserInfo");
            
            if (respuesta.IsSuccessStatusCode)
            {
                var user = await respuesta.Content.ReadAsAsync<List<CardUserDTO>>();
                return View(user);
            }
            else
            {
                return View("Error");
            }
        }




        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
