using Agenda.Contatos.Data;
using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Contatos.Repository
{
    public class TipoContatoRepository
    {
        private readonly DataContext _dataContext;

        public TipoContatoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TipoContatoModel Adicionar(TipoContatoModel tipoContato)
        {
            _dataContext.TiposContatos.Add(tipoContato);
            _dataContext.SaveChangesAsync();
            return tipoContato;
        }

        /// <summary>
        /// Buscar todos os tipos de contato cadastrados na base de dados.
        /// </summary>
        /// <returns></returns>
        public List<TipoContatoModel> BuscarTodos()
        {
            return _dataContext.TiposContatos.ToList();
        }

        /// <summary>
        /// Buscar tipo de contato no banco de dados com base em seu nome.
        /// </summary>
        /// <param name="nome">Nome do tipo de contato.</param>
        /// <returns>Único tipo de contato correspondente ao nome.</returns>
        public TipoContatoModel BuscarPorNome(string nome)
        {
            return _dataContext.TiposContatos.FirstOrDefault(t => t.Nome == nome);
        }

        /// <summary>
        /// Excluir da base de dados um contato.
        /// </summary>
        /// <param name="nome">Nome do tipo de contato.</param>
        public bool ApagarTipoContato(string nome)
        {
            var tipoContatoDb = BuscarPorNome(nome);
            if (tipoContatoDb == null)
                throw new Exception("Tipo de contato não encontrado na base de dados.");
            else
            {
                _dataContext.TiposContatos.Remove(tipoContatoDb);
                _dataContext.SaveChanges();
                return true;
            }
        }
    }
}