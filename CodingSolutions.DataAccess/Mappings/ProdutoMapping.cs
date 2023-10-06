using CodingSolutions.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingSolutions.DataAccess.Mappings;

internal class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();
        builder.Property(x => x.Preco)
            .HasColumnType("DECIMAL(10,2)")
            .IsRequired();
        builder.HasMany(x => x.ProdutoPorCliente)
            .WithOne(x => x.Produto);
    }
}