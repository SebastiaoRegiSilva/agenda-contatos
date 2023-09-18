using Agenda.Contatos.Helper;
using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    //todo Implementar logs nas operações com logins.
    public class LoginController : Controller
    {
        // Injeção de depedência...
        private readonly IUsuarioRepository _usuarioRepository;

        // Injeção de depedência...
        private readonly ISession _session;

        // Injeção de dependência...
        private readonly IEmail _email;
            
        /// <summary>
        /// Construtor com parâmetros para inicialização.
        /// </summary>
        /// <param name="usuarioRepository"></param>
        /// <param name="session"></param>
        public LoginController(IUsuarioRepository usuarioRepository, ISession session, IEmail email)
        {
            _usuarioRepository = usuarioRepository;
            _session = session;
            _email = email;
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
                    UsuarioModel usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);
                    
                    if(usuario != null)
                    {
                        if(usuario.ValidarSenha(loginModel.Password))
                        {
                            _session.InicializarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                            
                        TempData["MensagemErro"] = $"Senha incorreta!";
                    }
                    
                    TempData["MensagemErro"] = $"Usuário e/ou senha incorreto(s)!";
                }
                return View("Index");
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

        /// <summary>
        /// Redefine nova senha do usuário.
        /// </summary>
        /// <returns>Tela de redefinição de senha.</returns>
        public IActionResult RedefinirSenha()
        {
            return View();
        }

        /// <summary>
        /// Redefine nova senha do usuário.
        /// </summary>
        [HttpPost]
        public IActionResult EnviarRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioRecuperado = _usuarioRepository.BuscarPorEmailLogin(redefinirSenhaModel.Login, redefinirSenhaModel.Email);

                    if (usuarioRecuperado != null)
                    {
                        string novaSenha = usuarioRecuperado.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é:{novaSenha}";
                        //Enviar e-mail
                        bool emailEnviado = _email.EnviarEmail(usuarioRecuperado.Email, "Sistema de contatos", mensagem);

                        if(emailEnviado)
                        {
                            _usuarioRepository.EditarUsuario(usuarioRecuperado);
                            TempData["MensagemSucesso"] = $"Enviamos para o e-mail cadastrado um nova senha de acesso!";
                        }
                        else
                            TempData["MensagemErro"] = $"Não foi possível enviar o e-mail, tente novamente, por favor!";

                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não foi possível redefinir a senha, verifique os dados inseridos!";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível redefinir a senha, tente novamente. Detalhe do erro : { erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
