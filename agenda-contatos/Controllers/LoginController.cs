using Agenda.Contatos.Helper;
using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    public class LoginController : Controller
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
        public LoginController(IUsuarioRepository usuarioRepository, ISession session)
        {
            _usuarioRepository = usuarioRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            // Se usuário estiver redirecionar para a index da Home.
            if (_session.BuscarSessaoUsuario() != null)
                RedirectToAction("Index", "Home");
            
            return View();
        }

        /// <summary>
        /// Inicializa uma sessão com usuário logado.
        /// </summary>
        /// <param name="loginModel">Login de acesso ao sistema.</param>
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    //UsuarioModel usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);
                    
                    // Acesso chumbado para implementação do front-end
                    if (loginModel == new LoginModel(){ Login = "jp", Password = "123"})
                    {
                        //if(usuario.ValidarSenha(loginModel.Password))
                        //{

                        //}
                            
                        //TempData["MensagemErro"] = $"Senha incorreta!";
                    }
                    
                    /// TempData["MensagemErro"] = $"Usuário e/ou senha incorreto(s)!";
                }
                UsuarioModel usuario = new() { Login = loginModel.Login, Senha = loginModel.Password };
                _session.InicializarSessaoUsuario(usuario);
                return RedirectToAction("Index", "Home");

                //return View("Index");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível logar com o usuário e senha. : { erro.Message}";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Encerra uma sessão de usuário logado.
        /// </summary>
        /// <returns>View de Login.</returns>
        public IActionResult EncerrarSessao ()
        {
            _session.FinalizarSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }
    }
}
