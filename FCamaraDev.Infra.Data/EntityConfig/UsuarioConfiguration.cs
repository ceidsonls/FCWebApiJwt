using System.Data.Entity.ModelConfiguration;
using FCamaraDev.Entity;
namespace FCamaraDev.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.UsuarioId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Senha)
            .IsRequired()
            .HasMaxLength(20);
        }
    }
}
