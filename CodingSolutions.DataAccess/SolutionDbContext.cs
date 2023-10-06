using CodingSolutions.DataAccess.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CodingSolutions.DataAccess;

public class SolutionDbContext : DbContext
{
    public SolutionDbContext(DbContextOptions<SolutionDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteMapping());
        modelBuilder.ApplyConfiguration(new ProdutoMapping());
        modelBuilder.ApplyConfiguration(new ClienteProdutoMapping());
    }

    public DbSet<Domain.Cliente> Clientes { get; set; }
    public DbSet<Domain.Produto> Produtos { get; set; }
    public DbSet<Domain.ProdutoCliente> ProdutosClientes { get; set; }
}