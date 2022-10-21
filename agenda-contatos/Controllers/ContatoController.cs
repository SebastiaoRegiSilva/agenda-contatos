using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public IActionResult BuscarContato()
        {
            return View();
        }

        public IActionResult EditarContato()
        {
            return View();
        }

        public JsonResult ApagarContato()
        {
            return Json("Contato Apagado");
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
    }
}
