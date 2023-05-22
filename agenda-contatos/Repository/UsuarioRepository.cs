using Agenda.Contatos.Data;
using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Contatos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Contexto utilizado pelo repositório de usuários .</summary> 
        /// </summary>
        private readonly DataContext _dataContext;

       public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Excluir da base de dados um usuário.
        /// </summary>
        /// <param name="id">Código de identificação do usuário.</param>
        public bool ApagarUsuario(int id)
        {
            var usuarioDb = BuscarUsuarioPorId(id);
            if (usuarioDb == null)
                throw new Exception("Usuário não encontrado na base de dados.");
            else
            {
                _dataContext.Usuarios.Remove(usuarioDb);
                _dataContext.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Buscar usuário no banco de dados com base em seu login.
        /// </summary>
        /// <param name="login">Chave de acesso do usuário ao sistema.</param>
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _dataContext.Usuarios.FirstOrDefault(c => c.Login.ToUpper() == login.ToUpper());
        }

        /// <summary>
        /// Buscar usuário no banco de dados com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do usuário.</param>
        /// <returns>Único usuário correspondente ao código de identificação.</returns>
        public UsuarioModel BuscarUsuarioPorId(int id)
        {
            return _dataContext.Usuarios.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Buscar todos dados dos usuários cadastrados na base de dados.
        /// </summary>
        /// <returns>Todos usuário cadastrados.</returns>
        public List<UsuarioModel> BuscarTodosUsuarios()
        {
            return _dataContext.Usuarios.ToList();
        }

        /// <summary>
        /// Cadastrar um usuário na base de dados.
        /// </summary>
        public UsuarioModel CadastrarUsuario(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChangesAsync();
            
            return usuario;
        }
               
        /// <summary>
        /// Editar usuário no banco de dados com base no usuário. - Melhorar!
        /// </summary>
        /// <param name="usuario"></param>
        public UsuarioModel EditarUsuario(UsuarioModel usuario)
        {
            var usuarioDb = BuscarUsuarioPorId(usuario.Id);
            if (usuarioDb == null)
                throw new Exception("Erro de edição do usuário!");
            else
            {
                usuarioDb.Email = usuario.Email;
                usuarioDb.Login = usuario.Login;
                usuarioDb.Nome = usuario.Nome;
                usuarioDb.NivelPermissao = usuario.NivelPermissao;
                usuarioDb.DataAtualizacao = DateTime.Now;
                
                _dataContext.Usuarios.Update(usuarioDb);
                _dataContext.SaveChanges();

                return usuarioDb;
            }
        }
    }
}
