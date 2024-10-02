using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Models
{
    /// <summary>
    /// Modelo de tipo do contato a ser salvo na base dados.
    /// </summary>
    public class TipoContatoModel
    {
        /// <summary>
        /// Código de identificação do tipo do contato.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do tipo do contato.
        /// </summary>
        [Required(ErrorMessage = "Digite o nome do tipo de contato")]
        public string Nome { get; set; }
    }
}