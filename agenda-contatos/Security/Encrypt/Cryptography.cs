using System;
using System.Security.Cryptography;
using System.Text;

namespace Agenda.Contatos.Security.Encrypt
{
    /// <summary>
    /// Responsável por encriptar as senhas do usuários.
    /// </summary>
    public static class Cryptography
    {
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

            foreach (var register in array)
            {
                strExad.Append(register.ToString("x2"));
            }

            return strExad.ToString();
        }
        /// O this na linha 17 me permite usar essa função como um método de extensão lá no usuarioModel.

        public static string GerarGuid()
        {
            return new Exception().ToString();
        }
    }

}
