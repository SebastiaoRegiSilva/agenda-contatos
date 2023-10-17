using Agenda.Contatos.Enums;
using Agenda.Contatos.Security.Encrypt;
using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Models
{
    /// <summary>
    /// Modelo de um usuário a ser salvo na base dados.
    /// </summary>
    public class UsuarioModel
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
        /// Senha do usuário de acesso ao sistema.
        /// Implementar melhorias, criptografar, SALT.
        /// </summary>
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }

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
        
        /// <summary>
        /// Data de cadastro do usuário.
        /// </summary>
        public DateTime DataCadastro { get; set; }
        
        /// <summary>
        /// Data de alteração em alguma das propriedades do usuário.
        /// </summary>
        public DateTime? DataAtualizacao { get; set; }

        /// <summary>
        /// Validação simples de verificação de senha inserida pelo usuário na tela de login.
        /// </summary>
        /// <param name="senha">Senha do usuário de acesso ao sistema.</param>
        /// <returns></returns>
        public bool ValidarSenha(string senha)
        {
            return Senha == senha.GerarHash();
        }

        /// <summary>
        /// Responsável com criptografar a senha antes de persisti-la no banco de dados.
        /// </summary>
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        /// <summary>
        /// Gerar nova senha para usuário, para redefinição de senha.
        /// </summary>
        /// <returns>Nova senha de acesso ao sistema.</returns>
        public string GerarNovaSenha ()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }

        /// <summary>
        /// Responsável por criação de nova senha de usuário no banco de dados.
        /// </summary>/
        /// <param name="novaSenha">Nova senha do usuário de acesso ao sistema.</param>
        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
    }
}
