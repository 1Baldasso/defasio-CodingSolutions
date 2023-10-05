using Microsoft.EntityFrameworkCore;

namespace CodingSolutions.DataAccess;

public class SolutionDbContext : DbContext
{
    public SolutionDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<Domain.Cliente> Clientes { get; set; }
    public DbSet<Domain.Produto> Produtos { get; set; }
    public DbSet<Domain.ProdutoCliente> ProdutosClientes { get; set; }
}