using Agenda.Contatos.Data;
using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Contatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly DataContext _dataContext;
        
        public ContatoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _dataContext.Contatos.Add(contato);
            _dataContext.SaveChangesAsync();
            return contato;
        }

        /// <summary>
        /// Buscar todos dados cadastrados na base de dados.
        /// </summary>
        /// <returns></returns>
        public List<ContatoModel> BuscarTodos()
        {
            return _dataContext.Contatos.ToList();
        }

        /// <summary>
        /// Buscar contato no banco de dados com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do contato.</param>
        /// <returns>Único contato correspondente ao código de identificação.</returns>
        public ContatoModel BuscarPorId(int id)
        {
            return _dataContext.Contatos.FirstOrDefault(c =>c.Id == id);
        }

        /// <summary>
        /// Editar contato no banco de dados com base no contato. - Melhorar!
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public ContatoModel EditarContato(ContatoModel contato)
        {
            var contatoDb = BuscarPorId(contato.Id);
            if (contatoDb == null)
                throw new Exception("Erro de edição do contato!");
            else
            {
                contatoDb.Email = contato.Email;
                contatoDb.Estado = contato.Estado;
                contatoDb.Nome = contato.Nome;
                contatoDb.NumeroCelular = contato.NumeroCelular;
                contatoDb.Pais = contato.Pais;
                contatoDb.Tipo = contato.Tipo;

                _dataContext.Contatos.Update(contatoDb);
                _dataContext.SaveChanges();

                return contatoDb;
            }
        }

        /// <summary>
        /// Excluir da base de dados um contato.
        /// </summary>
        /// <param name="id">Código de identificação do contato.</param>
        public bool ApagarContato(int id)
        {
            var contatoDb = BuscarPorId(id);
            if (contatoDb == null)
                throw new Exception("Contato não encontrado na base de dados.");
            else
            {
                _dataContext.Contatos.Remove(contatoDb);
                _dataContext.SaveChanges();
                return true;
            }
        }
    }
}
