using Agenda.Contatos.Data;
using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
