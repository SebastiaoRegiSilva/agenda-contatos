using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    public class TipoContatoController : Controller
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        /// <summary>
        /// Construtor com injeção de dependência.
        /// </summary>
        /// <param name="tipoContatoRepository">Tipo de contato no repositório.</param>
        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        public IActionResult CriarTipoContato()
        {
            return View();
        }

        public IActionResult BuscarTipoContato()
        {
            return View();
        }

        /// <summary>
        /// Exclusão após confirmação.
        /// </summary>
        /// <param name="nome">Nome do tipo de contato.</param>
        public IActionResult ApagarTipoContato(string nome)
        {
            try
            {
                var apagado = _tipoContatoRepository.ApagarTipoContato(nome);
                if (apagado)
                    TempData["MensagemSucesso"] = "apagado";
                else
                    TempData["MensagemErro"] = $"Ops, tipo de contato não foi apagado!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, tipo contato não foi apagado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Confirmar exclusão do tipo contato.
        /// </summary>
        /// <param name="nome">Nome do tipo de contato a ser excluído.</param>
        public IActionResult ApagarConfirmacao(string nome)
        {
            var tipoContatoRecuperado = _tipoContatoRepository.BuscarPorNome(nome);
            return View(tipoContatoRecuperado);
        }
        // Métodos POST.
        [HttpPost]
        public IActionResult CriarTipoContato(TipoContatoModel tipoContato)
        {
            try
            {
                // Validação com Data Annotations.
                if (ModelState.IsValid)
                {
                    _tipoContatoRepository.Adicionar(tipoContato);
                    TempData["MensagemSucesso"] = "cadastrado";
                    return RedirectToAction("Index");
                }

                return View(tipoContato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, tipo de contato não foi cadastrado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
