using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Models
{
    /// <summary>
    /// Modelo de redefinição de senha de acesso ao sistema. 
    /// </summary>
    public class RedefinirSenhaModel
    {
        /// <summary>
        /// Login de acesso ao sistema.
        /// </summary>
        [Required(ErrorMessage = "Digite o seu login de acesso")]
        public string Login { get; set; }

        /// <summary>
        /// Senha de acesso ao sistema.
        /// </summary>
        [Required(ErrorMessage = "Digite o seu email")]
        public string Email { get; set; }
    }
}
