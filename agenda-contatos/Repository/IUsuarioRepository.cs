using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Repository
{
    /// <summary>Interface que padroniza o repositório de usuários.</summary>
    public interface IUsuarioRepository
    {
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
