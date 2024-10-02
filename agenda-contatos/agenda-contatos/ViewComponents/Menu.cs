using Agenda.Contatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Agenda.Contatos.ViewComponents
{
    public class Menu : ViewComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>View que está em Components/Menu/Default.</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession))
                return null;

            UsuarioModel usuarioLogado = JsonConvert.DeserializeObject<UsuarioModel>(userSession);

            return View(usuarioLogado);
        }
    }
}
