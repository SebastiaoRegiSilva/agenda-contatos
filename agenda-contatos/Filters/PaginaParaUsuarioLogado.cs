using Agenda.Contatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace Agenda.Contatos.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute
    {
        /// <summary>
        /// Verificar antes de executar cada action se o usuário está logado.
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession))
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(userSession);

                if(usuario is null)
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
             
            base.OnActionExecuting(context);
        }
    }
}
