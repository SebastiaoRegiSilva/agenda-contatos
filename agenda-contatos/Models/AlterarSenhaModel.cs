using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Models
{
    /// <summary>
    /// Modelo de uma alteração de senha a ser salva na base dados.
    /// </summary>
    public class AlterarSenhaModel
    {
        /// <summary>
        /// Código de identificação do usuário que terá senha alterada.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Senha do usuário de acesso ao sistema.
        /// Implementar melhorias, criptografar, SALT.
        /// </summary>
        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        
        public string SenhaAtual { get; set; }
        /// <summary>
        /// Nova senha do usuário de acesso ao sistema.
        /// </summary>
        [Required(ErrorMessage = "Digite nova senha do usuário")]
        public string NovaSenha { get; set; }

        /// <summary>
        /// Confirmar nova senha do usuário de acesso ao sistema.
       /// </summary>
        [Required(ErrorMessage = "Confirme a nova senha do usuário")]
        [Compare("NovaSenha", ErrorMessage = "Senhas não são iguais!")]
        public string ConfirmarSenha { get; set; }
    }
}
