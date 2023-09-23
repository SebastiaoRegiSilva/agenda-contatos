using Agenda.Contatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
