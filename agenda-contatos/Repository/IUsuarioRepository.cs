using Agenda.Contatos.Models;
using System.Collections.Generic;

namespace Agenda.Contatos.Repository
{
    /// <summary>Interface que padroniza o repositório de usuários.</summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        ///  Busca no repositório um usuário com base em seu login.
        /// </summary>
        /// <param name="login">Chave de acesso do usuário ao sistema.</param>
        /// <returns></returns>
        UsuarioModel BuscarPorLogin(string login);

        /// <summary>
        ///  Busca no repositório um usuário com base em seu login e email.
        /// </summary>
        /// <param name="login">Chave de acesso do usuário ao sistema.</param>
        /// <param name="email">E-mail de acesso do usuário ao sistema.</param>
        /// <returns>Usuário com base em seu e-mail e login.</returns>
        UsuarioModel BuscarPorEmailLogin(string login, string email);

        /// <summary>
        /// Busca no repositório um usuário com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do usuário.</param>
        /// <returns>Usuário recuperado.</returns>
        UsuarioModel BuscarUsuarioPorId(int id);

        /// <summary>
        /// Busca todos usuários cadastrados no repositório.
        /// </summary>
        /// <returns>Todos usuários cadastrados.</returns>
        List<UsuarioModel> BuscarTodosUsuarios();

        /// <summary>
        /// Cadastra no repositório um usuário.
        /// </summary>
        /// <param name="usuario">Modelo de um usuário.</param>
        /// <returns></returns>
        UsuarioModel CadastrarUsuario(UsuarioModel usuario);

        /// <summary>
        /// Edita no repositório um usuário.
        /// </summary>
        /// <param name="usuario">Modelo de um usuário.</param>
        UsuarioModel EditarUsuario(UsuarioModel usuario);

        /// <summary>
        /// Apaga no repositório um usuário com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do usuário.</param>
        /// <returns>Confirmação ou não da boa sucessão da operação.</returns>
        bool ApagarUsuario(int id);
    }
}
