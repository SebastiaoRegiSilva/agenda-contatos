using Agenda.Contatos.Filters;
using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    [PaginaRestritaParaAdmin]
    /// <summary>Controller que provê endpoints relacionados à entidade tipo de contato.</summary>
    public class TipoContatoController : Controller
    {
        /// <summary>Serviço que provê acesso aos dados e operações relacionadas aos tipos de contato.</summary>
        private readonly ITipoContatoRepository _tipoContatoRepository;

        /// <summary>
        /// Construtor com injeção de dependência.
        /// </summary>
        /// <param name="tipoContatoRepository"></param>
        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        public IActionResult Index()
        {
            var tiposContato = _tipoContatoRepository.BuscarTodosTipoContato();

            return View(tiposContato);
        }

        public IActionResult CadastrarTipoContato()
        {
            return View();
        }

        /// <summary>
        /// Exclusão após confirmação.
        /// </summary>
        public IActionResult ApagarTipoContato(int id)
        {
            // Validações
            // Criar um função para verificar se há algum contato com esse tipo de contato cadastro e impedir a exclusão.
            try
            {
                var apagado = _tipoContatoRepository.ApagarTipoContato(id);
                if (apagado)
                    TempData["MensagemSucesso"] = "apagado";
                
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = $"Tipo de contato não pode ser apagado por está vinculado à algum contato.";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Confirmar exclusão do tipo de contato.
        /// </summary>
        /// <param name="id">Código de identificação do tipo de contato a ser excluído.</param>
        public IActionResult ApagarConfirmacao(int id)
        {
            var tipoDeContatoRecuperado = _tipoContatoRepository.BuscarTipoContatoPorId(id);
            return View(tipoDeContatoRecuperado);
        }

        // Métodos POST.
        [HttpPost]
        public IActionResult CadastrarTipoContato(TipoContatoModel tipoContato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tipoContatoRepository.CadastrarTipoContato(tipoContato);
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
