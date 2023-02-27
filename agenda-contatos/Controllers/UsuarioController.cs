using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Construtor com injeção de dependência.
        /// </summary>
        /// <param name="usuarioRepository"></param>
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            return View();
        }

        public IActionResult EditarUsuario(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            return View(usuario);
        }

        /// <summary>
        /// Exclusão após confirmação.
        /// </summary>
        public IActionResult ApagarUsuario(int id)
        {
            try
            {
                var apagado = _usuarioRepository.ApagarContato(id);
                if (apagado)
                    TempData["MensagemSucesso"] = "apagado";
                else
                    TempData["MensagemErro"] = $"Ops, usuário não foi apagado!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, usuário não foi apagado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Confirmar exclusão do usuário.
        /// </summary>
        /// <param name="id">Código de identificação do usuário a ser excluído.</param>
        public IActionResult ApagarConfirmacao(int id)
        {
            var usuarioRecuperado = _usuarioRepository.BuscarPorId(id);
            return View(usuarioRecuperado);
        }
    }
}
