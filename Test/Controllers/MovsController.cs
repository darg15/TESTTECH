using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Test.DTO;

namespace Test.Controllers
{
    public class MovsController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<MovsController> _logger;

        public MovsController(IHttpClientFactory httpClient, IConfiguration configuration, ILogger<MovsController> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient.CreateClient("Servicio");
            _logger = logger;
        }
        public IActionResult Index(int id, string clientName, string tarjeta)
        {
            ViewBag.Id= id;
            ViewBag.ClientName= clientName;
            ViewBag.Tarjeta = tarjeta;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewMov(MovDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo invalido");
                return View(model);
            }

            try
            {
                var respuesta = await _httpClient.PostAsJsonAsync("Movs/Mov", model);
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Card");
                }
                else
                {
                   
                    _logger.LogError("Detalles: ", respuesta.StatusCode);
                    return View();
                }
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Error inesperado");
                return View("Error");
            }

        }
    }
}
