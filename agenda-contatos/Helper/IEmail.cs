namespace Agenda.Contatos.Helper
{
    /// <summary>
    /// Interface que padroniza a gestão de envio de e-mails.
    /// </summary>
    public interface IEmail
    {
        /// <summary>
        /// Enviar e-mail.
        /// </summary>
        /// <param name="endEmail">Endereço que receberá o e-mail.</param>
        /// <param name="assunto">Assunto do e-mail.</param>
        /// <param name="mensagem">Conteúdo do e-mail.</param>
        bool EnviarEmail(string endEmail, string assunto, string mensagem);

    }
}
