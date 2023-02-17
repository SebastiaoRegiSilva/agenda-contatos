using Agenda.Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Contatos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<TipoContatoModel> TiposContatos { get; set; }
    }
}
