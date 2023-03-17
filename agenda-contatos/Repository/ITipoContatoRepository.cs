using Agenda.Contatos.Models;
using System.Collections.Generic;

namespace Agenda.Contatos.Repository
{
    /// <summary>Interface que padroniza o repositório dos tipos de contato.</summary>
    interface ITipoContatoRepository
    {
        /// <summary>
        /// Cadastra no repositório um tipo de contato.
        /// </summary>
        /// <param name="tipoContato">Modelo de um tipo de contato.</param>
        TipoContatoModel CadastrarTipoContato(TipoContatoModel tipoContato);

        /// <summary>
        /// Apaga no repositório um tipo de contato com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação de um tipo de contato.</param>
        /// <returns>Sim ou Não para a boa sucessão da operação na base de dados.</returns>
        bool ApagarTipoContato(int id);

        /// <summary>
        /// Busca no repositório todos os tipo de contato cadastrados.
        /// </summary>
        /// <returns>Lista de tipos de contato.</returns>
        List<TipoContatoModel> BuscarTodosTipoContato();

        /// <summary>
        /// Edita no repositório um tipo de contato com base em seu código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação de um tipo de contato.</param>
        TipoContatoModel BuscarTipoContatoPorId(int id);

        /// <summary>
        /// Edita no repositório um tipo de contato.
        /// </summary>
        /// <param name="tipoContato">Modelo de um tipo de contato.</param>
        TipoContatoModel EditarTipoContato(TipoContatoModel tipoContato);
    }
}