using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
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

        public IActionResult BuscarTipoContato()
        {
            return View();
        }

        public IActionResult EditarTipoContato(int id)
        {
            var tipoDeContato = _tipoContatoRepository.BuscarTipoContatoPorId(id);

            return View(tipoDeContato);
        }

        /// <summary>
        /// Exclusão após confirmação.
        /// </summary>
        public IActionResult ApagarTipoContato(int id)
        {
            try
            {
                var apagado = _tipoContatoRepository.ApagarTipoContato(id);
                if (apagado)
                    TempData["MensagemSucesso"] = "apagado";
                else
                    TempData["MensagemErro"] = $"Ops, tipo de contato não foi apagado!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, tipo de contato não foi apagado! ERRO =>{ex.Message}";
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
    }
}
