using System;

namespace agenda_contatos.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Teste de comentrio.
        /// </summary>
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
