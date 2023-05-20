using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    /// <summary>Controller que provê endpoints relacionados à entidade usuário.</summary>
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

        /// <summary>
        /// Página inicial que exibe todos usuários cadastrados.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var usuarios = _usuarioRepository.BuscarTodosUsuarios();

            return View(usuarios);
        }

        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            return View();
        }

        /// <summary>
        /// Edita um usuário com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do usuário.</param>
        /// <returns>View de edição.</returns>
        public IActionResult EditarUsuario(int id)
        {
            var usuario = _usuarioRepository.BuscarUsuarioPorId(id);

            return View(usuario);
        }

        /// <summary>
        /// Exclusão após confirmação.
        /// </summary>
        public IActionResult ApagarUsuario(int id)
        {
            try
            {
                var apagado = _usuarioRepository.ApagarUsuario(id);
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
            var usuarioRecuperado = _usuarioRepository.BuscarUsuarioPorId(id);
            return View(usuarioRecuperado);
        }

        // Métodos POST.
        [HttpPost]
        public IActionResult CadastrarUsuario(UsuarioModel usuario)
        {
            try
            {
                // Validação com Data Annotations.
                if (ModelState.IsValid)
                {
                    _usuarioRepository.CadastrarUsuario(usuario);
                    TempData["MensagemSucesso"] = "cadastrado";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, usuário não foi cadastrado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Editar um usuário sem senha com base em seu código de identificação.
        /// </summary>
        /// <param name="usuarioSemSenha">Usuário sem senha.</param>
        [HttpPost]
        public IActionResult EditarUsuario(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;
                // Validação com Data Annotations.
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        NivelPermissao = usuarioSemSenha.NivelPermissao
                    };
                    
                    usuario = _usuarioRepository.EditarUsuario(usuario);
                    TempData["MensagemSucesso"] = "alterado";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, usuário sem senha não foi editado! ERRO =>{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
