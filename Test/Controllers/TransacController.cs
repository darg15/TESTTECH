using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Test.DTO;

namespace Test.Controllers
{
    public class TransacController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TransacController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration = configuration;
            _httpClient = httpClient.CreateClient("Servicio");
        }
        public async Task<IActionResult> Index(string id)
        {
            var respuesta = await _httpClient.GetAsync($"Transac/GetTransac/{id}");
            List<TransaccionesDTO> transac = new List<TransaccionesDTO>();
            if (respuesta.IsSuccessStatusCode)
            {
                transac = await respuesta.Content.ReadAsAsync<List<TransaccionesDTO>>();
                
            }
            return View(transac);

        }
    }
}
