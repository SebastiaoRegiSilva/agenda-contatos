using Agenda.Contatos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Models
{
    public class UsuarioModel
    {
        
        /// <summary>
        /// Código de identificação do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Chave de acesso do usuário ao sistema.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Senha do usuário de acesso ao sistema.
        /// Implementar melhorias, criptografar, SALT.
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Email do usuário para busca e eventual recuperação de acesso.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Nível de acesso às funcionalidades do sistema.
        /// </summary>
        public Permissao NivelPermissao { get; set; }
        
        /// <summary>
        /// Data de cadastro do usuário.
        /// </summary>
        public DateTime DataCadastro { get; set; }
        
        /// <summary>
        /// Data de alteração em alguma das propriedades do usuário.
        /// </summary>
        public DateTime? DataAtualizacao { get; set; }
    }
}
