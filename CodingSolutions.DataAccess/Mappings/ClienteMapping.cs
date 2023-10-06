using CodingSolutions.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingSolutions.DataAccess.Mappings;

internal class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();
        builder.Property(x => x.Email)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();
        builder.Property(x => x.CPF)
            .HasColumnType("CHAR(11)")
            .IsRequired();
        builder.HasIndex(x => x.CPF)
            .IsUnique();
        builder.HasMany(x => x.ProdutoPorCliente)
            .WithOne(x => x.Cliente);

        builder.Property(x => x.Saldo)
            .HasColumnType("DECIMAL(10,2)")
            .HasDefaultValue(500)
            .IsRequired();
    }
}