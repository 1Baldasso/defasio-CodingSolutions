namespace CodingSolutions.Domain.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ListAllAsync(CancellationToken ct = default);

    Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct = default);

    Task CreateAsync(Produto produto, CancellationToken ct = default);

    Task UpdateAsync(Produto produto, CancellationToken ct = default);

    void Delete(Guid id);

    Task ComprarAsync(Guid id, Guid clienteId, CancellationToken ct);
}