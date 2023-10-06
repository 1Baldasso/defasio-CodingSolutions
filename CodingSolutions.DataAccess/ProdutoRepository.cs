using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodingSolutions.DataAccess;

internal class ProdutoRepository : IProdutoRepository
{
    private readonly SolutionDbContext _context;

    public ProdutoRepository(SolutionDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Produto produto, CancellationToken ct = default)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync(ct);
    }

    public async Task Delete(Guid id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }

    public async Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Produtos.Include(x => x.ProdutoPorCliente)
            .ThenInclude(x => x.Cliente)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<IEnumerable<Produto>> ListAllAsync(CancellationToken ct = default)
    {
        return await _context.Produtos.Include(x => x.ProdutoPorCliente)
            .ThenInclude(x => x.Cliente)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task UpdateAsync(Produto produto, CancellationToken ct = default)
    {
        var originalProduto = await _context.Produtos.FindAsync(produto.Id, ct);
        if (originalProduto == null) throw new Exception("Produto não encontrado");
        _context.Entry(originalProduto).CurrentValues.SetValues(produto);
        await _context.SaveChangesAsync(ct);
    }
}