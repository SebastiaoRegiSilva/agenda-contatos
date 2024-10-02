using Agenda.Contatos.Helper;
using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    public class NovaSenhaController : Controller
    {
        // Injeção de depedência...
        private readonly IUsuarioRepository _usuarioRepository;

        // Injeção de depedência...
        private readonly ISession _session;

        /// <summary>
        /// Construtor com parâmetros para inicialização.
        /// </summary>
        /// <param name="usuarioRepository"></param>
        /// <param name="session"></param>
        public NovaSenhaController(IUsuarioRepository usuarioRepository, ISession session)
        {
            _usuarioRepository = usuarioRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Alterar senha de usuário, a partir de inserção de senha atual.
        /// </summary>
        /// <param name="alterarSenhaModel">Objeto de alteração de senha</param>
        [HttpPost]
        public IActionResult AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _session.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepository.AlterarSenha(alterarSenhaModel);

                    TempData["MensagemSucesso"] = $"Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Erro na alteração da senha! ERRO =>{error.Message}";
                return RedirectToAction("Index", alterarSenhaModel);
            }
        }
    }
}
