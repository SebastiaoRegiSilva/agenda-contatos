using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Models
{
    /// <summary>
    /// Modelo de login de acesso ao sistema. 
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Login de acesso ao sistema.
        /// </summary>
        [Required(ErrorMessage = "Digite o seu login de acesso")]
        public string Login { get; set; }

        /// <summary>
        /// Senha de acesso ao sistema.
        /// </summary>
        [Required(ErrorMessage = "Digite a senha correta")]
        public string Password { get; set; }
    }
}
