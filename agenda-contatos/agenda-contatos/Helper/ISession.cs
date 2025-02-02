using Agenda.Contatos.Models;

namespace Agenda.Contatos.Helper
{
    /// <summary>
    /// Interface que padroniza as sessões de usuários logados.
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Inicializa uma sessão de usuário logado.
        /// </summary>
        /// <param name="usuarioModel">Usuário que tem acesso ao sistema</param>
        void InicializarSessaoUsuario(UsuarioModel usuarioModel);

        /// <summary>
        /// Finaliza uma sessão de usuário logado.
        /// </summary>
        void FinalizarSessaoUsuario();

        /// <summary>
        /// Busca o usuário logado.
        /// </summary>
        UsuarioModel BuscarSessaoUsuario();
    }
}
