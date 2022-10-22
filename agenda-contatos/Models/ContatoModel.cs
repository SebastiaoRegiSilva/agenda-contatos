using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Models
{
    public class ContatoModel
    {
        /// <summary>
        /// Código de identificação do contato.
        /// </summary>
        public int Id{ get; set; }

        /// <summary>
        /// Nome do contato.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Endereço de e-mail do contato.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Número de celular.
        /// </summary>
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
        public string Tipo{ get; set; }
    }
}
