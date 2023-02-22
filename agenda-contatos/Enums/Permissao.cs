using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Enums
{
    /// <summary>
    /// Níveis de permissão para cada usuário.
    /// </summary>
    public enum Permissao
    {
        /// <summary>
        /// Acesso especial à todas funcionalidades do sistema.
        /// </summary>
        Admin = 1,
        
        /// <summary>
        /// Acesso mínimo às funcionalidados do sistema.
        /// </summary>
        Padrao = 2,
    }
}
