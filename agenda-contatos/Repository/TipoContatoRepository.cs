using Agenda.Contatos.Data;
using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Contatos.Repository
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        /// <summary>
        /// Contexto utilizado pelo repositório de tipos de contato .</summary> 
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataContext"></param>
        public TipoContatoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Apagar na base de dados um tipo de contato.
        /// </summary>
        /// <param name="id">Código de identificação do tipo de contato.</param>
        public bool ApagarTipoContato(int id)
        {
            var tipoContatoDb = BuscarTipoContatoPorId(id);
            if (tipoContatoDb == null)
                throw new Exception("O tipo de contato não foi encontrado na base de dados.");
            else
            {
                _dataContext.TiposDeContato.Remove(tipoContatoDb);
                _dataContext.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Busca na base de dados um tipo de contato com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do tipo de contato.</param>
        /// <returns>Único tipo de contato correspondente ao código de identificação.</returns>
        public TipoContatoModel BuscarTipoContatoPorId(int id)
        {
            return _dataContext.TiposDeContato.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Busca na de dados todos os tipos de contato cadastrados.
        /// </summary>
        /// <returns>Lista com todos tipos de contato.</returns>
        public List<TipoContatoModel> BuscarTodosTipoContato()
        {
            return _dataContext.TiposDeContato.ToList();
        }

        /// <summary>
        /// Cadastra na base de dados um no tipo de contato.
        /// </summary>
        /// <param name="tipoContato">Modelo de tipo de contato a ser cadastrado.</param>
        public TipoContatoModel CadastrarTipoContato(TipoContatoModel tipoContato)
        {
            _dataContext.TiposDeContato.Add(tipoContato);
            _dataContext.SaveChangesAsync();
            return tipoContato;
        }

        /// <summary>
        /// Edita na base de dados um no tipo de contato.
        /// </summary>
        /// <param name="tipoContato">Modelo de tipo de contato a ser editado.</param>
        public TipoContatoModel EditarTipoContato(TipoContatoModel tipoContato)
        {
            var tipoContatoDb = BuscarTipoContatoPorId(tipoContato.Id);
            if (tipoContatoDb == null)
                throw new Exception("Erro de edição no tipo de contato!");
            else
            {
                tipoContatoDb.Nome = tipoContato.Nome;
                _dataContext.TiposDeContato.Update(tipoContatoDb);
                _dataContext.SaveChanges();

                return tipoContatoDb;
            }
        }
    }
}
