namespace CodingSolutions.Domain.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ListAllAsync(CancellationToken ct = default);

    Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct = default);

    Task CreateAsync(Produto produto, CancellationToken ct = default);

    Task UpdateAsync(Produto produto, CancellationToken ct = default);

    Task Delete(Guid id);
}