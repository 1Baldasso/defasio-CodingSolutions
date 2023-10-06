namespace CodingSolutions.Domain.Repositories;

public interface IComprasRepository
{
    Task ComprarAsync(Guid id, Guid clienteId, int quantidade, CancellationToken ct);

    Task<IEnumerable<ProdutoCliente>> HistoricoComprasAsync(CancellationToken ct);
}