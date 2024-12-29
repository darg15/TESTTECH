using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Test.DTO;

namespace Test.Controllers
{
    public class PaymentController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ILogger<PaymentController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PaymentController(IHttpClientFactory httpClient, IConfiguration configuration, ILogger<PaymentController> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient.CreateClient("Servicio");
            _logger = logger;
        }


        public IActionResult Index(int id, string clientName, string tarjeta)
        {
            ViewBag.Id = id;
            ViewBag.ClientName = clientName;
            ViewBag.Tarjeta = tarjeta;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> NewPayment(PagoDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo no validp");
                return View(model);
            }

            try
            {
                var respuesta = await _httpClient.PostAsJsonAsync("Payments/Pay", model);
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Card");
                }
                else
                {

                    _logger.LogError("Detalles del error:", respuesta.StatusCode);
                    return View("Error");
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
