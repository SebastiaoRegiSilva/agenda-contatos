using Agenda.Contatos.Filters;
using Agenda.Contatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agenda.Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Conteúdo sobre o desenvolvedor e tecnologias utilizadas na apliação.
        /// </summary>
        /// <returns>Informações sobre o desenvolvedor.</returns>
        public IActionResult Sobre()
        {
            return View();
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
