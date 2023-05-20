using Agenda.Contatos.Models;
using Agenda.Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
            
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

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
                            return RedirectToAction("Index", "Home");
                        
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
    }
}
