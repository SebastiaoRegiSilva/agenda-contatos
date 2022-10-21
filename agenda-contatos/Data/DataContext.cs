using Agenda.Contatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Data
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Construtor com injeção de depedência.
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
