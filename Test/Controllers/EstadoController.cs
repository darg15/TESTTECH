using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using Test.DTO;

namespace Test.Controllers
{
    public class EstadoController : Controller
    {


        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public EstadoController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient.CreateClient("Servicio");
        }
        public async Task<IActionResult> Index(string id)
        {
            var respuesta = await _httpClient.GetAsync($"Estado/GetEstado/{id}");

            List<EstadoDTO> estado = new List<EstadoDTO>();

            if (respuesta.IsSuccessStatusCode)
            {
                estado = await respuesta.Content.ReadAsAsync<List<EstadoDTO>>();
            }

            return View(estado);
        }
    }
}
