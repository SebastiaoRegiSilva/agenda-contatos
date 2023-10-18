using Agenda.Contatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Contatos.Data.Map
{
    /// <summary>
    /// Mapeamento de contatos.
    /// </summary>
    public class MapContact : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
