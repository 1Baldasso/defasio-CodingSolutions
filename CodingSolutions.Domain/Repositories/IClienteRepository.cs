namespace CodingSolutions.Domain.Repositories;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ListAllAsync(CancellationToken ct = default);

    Task<Cliente?> GetByIdAsync(Guid id, CancellationToken ct = default);

    Task CreateAsync(Cliente cliente, CancellationToken ct = default);

    Task UpdateAsync(Cliente cliente, CancellationToken ct = default);

    Task Delete(Guid id);
}