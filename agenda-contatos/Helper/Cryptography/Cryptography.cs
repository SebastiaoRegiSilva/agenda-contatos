using System;
using System.Security.Cryptography;
using System.Text;

namespace Agenda.Contatos.Helper.Cryptography
{
    /// <summary>
    /// Responsável por encriptar as senhas do usuários.
    /// </summary>
    public static class Cryptography
    {
        /// <summary>
        ///  Gerar um (GUID)globally unique identifier - Indentificador global único.
        /// </summary>
        /// <param name="value">Valor do qual será gerado um GUID.</param>
        /// <returns></returns>
        public static string GerarGuid(this string value)
        {
            var guid = new Guid(value);

            return guid.ToString();
        }

        /// <summary>
        /// Gerar um hash a partir do valor de entrada.
        /// </summary>
        /// <param name="value">Valor do qual será gerado um hash.</param>
        /// <returns></returns>
        public static string GerarHash(this string value)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(value);

            array = hash.ComputeHash(array);

            var strExad = new StringBuilder();

            foreach(var register in array)
            {
                strExad.Append(register.ToString("x2"));
            }

            return strExad.ToString();
        }
    }
}
