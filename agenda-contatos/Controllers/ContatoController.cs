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
            var contato = _contatoRepository.BuscarPorId(id);

            return View(contato);
        }

        /// <summary>
        /// Exclusão após confirmação.
        /// </summary>
        public IActionResult ApagarContato(int id)
        {
            _contatoRepository.ApagarContato(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Confirmar exclusão do contato.
        /// </summary>
        /// <param name="id">Código de identificação do contato a ser excluído.</param>
        public IActionResult ApagarConfirmacao(int id)
        {
            var contatoRecuperado = _contatoRepository.BuscarPorId(id);
            return View(contatoRecuperado);
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
        /// <param name="contato">Contato.</param>
        [HttpPost]
        public IActionResult EditarContato(ContatoModel contato)
        {
            _contatoRepository.EditarContato(contato);
            return RedirectToAction("Index");
        }
    }
}
