using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        
        /// <summary>
        /// Construtor com injeção de dependência.
        /// </summary>
        /// <param name="contatoRepository"></param>
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            var ctc = _contatoRepository.BuscarTodos();

            return View(ctc);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public IActionResult BuscarContato()
        {
            return View();
        }

        public IActionResult EditarContato(int id)
        {
            _contatoRepository.BuscarPorId(id);
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
        // Métodos POST.
        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Editar contato com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do contato.</param>
        [HttpPost]
        public IActionResult EditarContato(int id)
        {
            return View();
        }
    }
}
