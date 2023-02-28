using Agenda.Contatos.Data;
using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
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
            var usuarioDb = BuscarPorId(id);
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
        /// Buscar usuário no banco de dados com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do usuário.</param>
        /// <returns>Único usuário correspondente ao código de identificação.</returns>
        public UsuarioModel BuscarPorId(int id)
        {
            return _dataContext.Usuarios.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Buscar todos dados dos usuários cadastrados na base de dados.
        /// </summary>
        /// <returns></returns>
        public List<UsuarioModel> BuscarTodos()
        {
            return _dataContext.Usuarios.ToList();
        }

        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
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
            var usuarioDb = BuscarPorId(usuario.Id);
            if (usuarioDb == null)
                throw new Exception("Erro de edição do usuário!");
            else
            {
                usuarioDb.Email = usuario.Email;
                usuarioDb.Login = usuario.Login;
                usuarioDb.Nome = usuario.Nome;
                usuarioDb.NivelPermissao = usuario.NivelPermissao;
                usuarioDb.DataAtualizacao = DateTime.Now.Date;
                
                _dataContext.Usuarios.Update(usuarioDb);
                _dataContext.SaveChanges();

                return usuarioDb;
            }
        }
    }
}
