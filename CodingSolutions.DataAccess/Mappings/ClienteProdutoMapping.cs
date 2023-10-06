using CodingSolutions.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingSolutions.DataAccess.Mappings;

internal class ClienteProdutoMapping : IEntityTypeConfiguration<ProdutoCliente>
{
    public void Configure(EntityTypeBuilder<ProdutoCliente> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Produto)
            .WithMany(x => x.ProdutoPorCliente);

        builder.HasOne(x => x.Cliente)
            .WithMany(x => x.ProdutoPorCliente);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Quantidade)
            .IsRequired();
    }
}