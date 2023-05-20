using Agenda.Contatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Models
{
    /// <summary>
    /// Modelo de usuário com acesso ao sistema sem a senha. 
    /// </summary>
    public class UsuarioSemSenhaModel
    {
        /// <summary>
        /// Código de identificação do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        /// <summary>
        /// Chave de acesso do usuário ao sistema.
        /// </summary>
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        /// <summary>
        /// Email do usuário para busca e eventual recuperação de acesso.
        /// </summary>
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        /// <summary>
        /// Nível de acesso às funcionalidades do sistema.
        /// </summary>
        [Required(ErrorMessage = "Informe o tipo de permissão")]
        public Permissao? NivelPermissao { get; set; }
    }
}
