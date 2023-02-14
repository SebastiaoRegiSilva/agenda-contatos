using Agenda.Contatos.Models;
using System.Collections.Generic;

namespace Agenda.Contatos.Repository
{
    public interface ITipoContatoRepository
    {
        ///<summary>Buscar tipo de contato.</summary>
        ///<returns>Tipo de contato com base no nome.</returns>
        TipoContatoModel BuscarPorNome(string nome);

        ///<summary>Buscar tipo de contato.</summary>
        ///<returns>Todos os tipos de contato cadastrados no repositório.</returns>
        List<TipoContatoModel> BuscarTodos();

       ///<summary>Adicionar novo tipo de contato no repositório.</summary>
        TipoContatoModel Adicionar(TipoContatoModel contato);

        ///<summary>Solicitar a deleção de um tipo de contato no repositório.</summary>
        ///<returns>Status da solicitação.</returns>
        bool ApagarContato(string nome);
    }
}
