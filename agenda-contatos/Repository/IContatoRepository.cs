using Agenda.Contatos.Models;
using System.Collections.Generic;

namespace Agenda.Contatos.Repository
{
    public interface IContatoRepository
    {
        ContatoModel BuscarPorId(int id);

        List<ContatoModel> BuscarTodos();

        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel EditarContato(ContatoModel contato);

        bool ApagarContato(int id);
    }
}
