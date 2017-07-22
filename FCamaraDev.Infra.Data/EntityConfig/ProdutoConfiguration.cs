using System.Data.Entity.ModelConfiguration;
using FCamaraDev.Entity;

namespace FCamaraDev.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(c => c.ProdutoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(300);

            Property(c => c.Codigo)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Valor)
               .IsRequired();
        }
    }
}
