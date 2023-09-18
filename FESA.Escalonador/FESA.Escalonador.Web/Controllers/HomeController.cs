using FESA.Escalonador.Web.Helpers;
using FESA.Escalonador.Web.Models;
using FESA.Escalonador.Web.Models.Result;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FESA.Escalonador.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(List<int> chegadas, List<int> tamanhos, List<int> prioridades, int tipo)
        {
            Resultado resultado;

            try
            {
                resultado = EscalonadorHelper.RetornarResultadoDasExecucoes(chegadas, tamanhos, prioridades, tipo);
                resultado.PreencherDados();
                resultado.Sucesso = true;
                resultado.Mensagem = "Cálculo realizado com sucesso!";
            }
            catch (Exception exception)
            {
                resultado = new Resultado();
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível realizar o cálculo. Erro: {exception.Message}";
            }

            return View("Index", resultado);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}