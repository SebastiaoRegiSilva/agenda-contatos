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

        /// <summary>
        /// Criar um novo contato.
        /// </summary>
        public IActionResult CriarContato()
        {
            return View();
        }

        /// <summary>
        /// Buscar um contato existente.
        /// </summary>
        public IActionResult BuscarContato()
        {
            return View();
        }

        /// <summary>
        /// Editar um contato existente.
        /// </summary>
        public IActionResult EditarContato()
        {
            return View();
        }

        /// <summary>
        /// Apagar um contato existente.
        /// </summary>
        public IActionResult ApagarContato()
        {
            return View();
        }
    }
}
