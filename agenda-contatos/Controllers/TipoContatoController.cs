using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Controllers
{
    public class TipoContatoController : Controller
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        /// <summary>
        /// Construtor com injeção de dependência.
        /// </summary>
        /// <param name="tipoContatoRepository"></param>
        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }
    }
}
