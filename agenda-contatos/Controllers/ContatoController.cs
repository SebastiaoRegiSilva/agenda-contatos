using Agenda.Contatos.Filters;
using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    /// <summary>Controller que provê endpoints relacionados à entidade contato.</summary>
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
            try
            {
               var apagado = _contatoRepository.ApagarContato(id);
                if (apagado)
                    TempData["MensagemSucesso"] = "apagado";
                else
                    TempData["MensagemErro"] = $"Ops, contato não foi apagado!";
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, contato não foi apagado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
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
            try
            {
                // Validação com Data Annotations.
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "cadastrado";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, contato não foi cadastrado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Editar contato com base em seu código de identificação.
        /// </summary>
        /// <param name="contato">Contato.</param>
        [HttpPost]
        public IActionResult EditarContato(ContatoModel contato)
        {
            try
            {
                // Validação com Data Annotations.
                if (ModelState.IsValid)
                {
                    _contatoRepository.EditarContato(contato);
                    TempData["MensagemSucesso"] = "alterado";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, contato não foi editado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
