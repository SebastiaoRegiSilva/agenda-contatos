using Agenda.Contatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Agenda.Contatos.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Construtor com parâmetros para inicialização.
        /// </summary>
        public Session(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Inicializa uma sessão de usuário logado.
        /// </summary>
        public UsuarioModel BuscarSessaoUsuario()
        {
            string userSession = _httpContextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession))
                return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(userSession);
        }

        /// <summary>
        /// Finaliza uma sessão de usuário logado.
        /// </summary>
        public void FinalizarSessaoUsuario()
        {
            _httpContextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

        /// <summary>
        /// Busca o usuário logado.
        /// </summary>
        public void InicializarSessaoUsuario(UsuarioModel usuarioModel)
        {
            // Converter o usuário model para um objeto json, que será utilizada como value-string.
            string value = JsonConvert.SerializeObject(usuarioModel);

            _httpContextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", value);
        }
    }
}
