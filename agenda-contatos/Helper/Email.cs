using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace Agenda.Contatos.Helper
{
    //todo Implementar logs nas operações com emails.
    public class Email : IEmail
    {
        /// <summary>
        /// Injeção de depedência que fornece acesso às configurações no arquivo appsettings.json.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor com parâmetros para inicialização.
        /// </summary>
        /// <param name="configuration">Injeção de dependência.</param>
        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Enviar e-mails.
        /// </summary>
        /// <param name="endEmail">Endereço do receptor.</param>
        /// <param name="assunto">Assunto do e-mail.</param>
        /// <param name="mensagem">Mensagem informativa.</param>
        /// <returns>Efetuado com sucesso ou não.</returns>
        public bool EnviarEmail(string endEmail, string assunto, string mensagem)
        {
            try
            {
                string userName = _configuration.GetValue<string>("SMTP:UserName");
                string nome = "Authentication Service ";
                string host = _configuration.GetValue<string>("SMTP:Host");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(userName, nome),
                };

                mail.To.Add(endEmail);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(userName, senha);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (Exception)
            {
                // Implementar logs para registro de eventuais erros de envios.
                return false;
            }
        }
    }
}
