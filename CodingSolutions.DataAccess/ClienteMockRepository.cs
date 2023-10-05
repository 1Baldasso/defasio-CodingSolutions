using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;

namespace CodingSolutions.DataAccess;

public class ClienteMockRepository : IClienteRepository
{
    private static List<Cliente> Clientes = new List<Cliente>();

    public Task CreateAsync(Cliente cliente, CancellationToken ct = default)
    {
        cliente.Id = Guid.NewGuid();
        Clientes.Add(cliente);
        return Task.CompletedTask;
    }

    public void Delete(Guid id)
    {
    }

    public Task<Cliente?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return Task.FromResult(Clientes.FirstOrDefault(x => x.Id == id));
    }

    public Task<IEnumerable<Cliente>> ListAllAsync(CancellationToken ct = default)
    {
        return Task.FromResult<IEnumerable<Cliente>>(Clientes);
    }

    public Task UpdateAsync(Cliente cliente, CancellationToken ct = default)
    {
        return Task.CompletedTask;
    }
}