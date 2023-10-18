using Agenda.Contatos.Data.Map;
using Agenda.Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Contatos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TipoContatoModel> TiposDeContato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapContact());
            base.OnModelCreating(modelBuilder);
        }
    }
}
