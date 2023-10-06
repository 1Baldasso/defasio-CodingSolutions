using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodingSolutions.DataAccess;

internal class ClienteRepository : IClienteRepository
{
    private readonly SolutionDbContext _context;

    public ClienteRepository(SolutionDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Cliente cliente, CancellationToken ct = default)
    {
        await _context.Clientes.AddAsync(cliente, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task Delete(Guid id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            throw new Exception("Cliente não encontrado");
        }
        _context.Remove(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Clientes.Include(x => x.ProdutoPorCliente)
            .ThenInclude(x => x.Produto)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<IEnumerable<Cliente>> ListAllAsync(CancellationToken ct = default)
    {
        return await _context.Clientes.Include(x => x.ProdutoPorCliente)
            .ThenInclude(x => x.Produto)
            .ToListAsync(ct);
    }

    public async Task UpdateAsync(Cliente cliente, CancellationToken ct = default)
    {
        var clienteOriginal = await _context.Clientes.FindAsync(cliente.Id, ct);
        if (clienteOriginal == null)
        {
            throw new Exception("Cliente não encontrado");
        }
        _context.Entry(clienteOriginal).CurrentValues.SetValues(cliente);
        await _context.SaveChangesAsync(ct);
    }
}