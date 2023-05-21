using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Models
{
    /// Modelo de um contato a ser salvo na base dados.
    public class ContatoModel
    {
        /// <summary>
        /// Código de identificação do contato.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do contato.
        /// </summary>
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }

        /// <summary>
        /// Endereço de e-mail do contato.
        /// </summary>
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        /// <summary>
        /// Número de celular.
        /// </summary>
        [Required(ErrorMessage = "Digite o número de contato")]
        [Phone(ErrorMessage = "Número de contato inválido!")]
        public string NumeroCelular { get; set; }

        /// <summary>
        /// País o qual reside o proprietário do contato.
        /// </summary>
        public string Pais { get; set; }

        /// <summary>
        /// Estado/Província do contato.
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Tipo de contato (Criar ENUM em Lugar do IEnumerable).
        /// </summary>
        ///[Required(ErrorMessage = "Selecione o tipo de contato")]
        public TipoContatoModel Tipo{ get; set; }
    }
}
