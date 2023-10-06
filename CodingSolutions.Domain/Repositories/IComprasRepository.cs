namespace CodingSolutions.Domain.Repositories;

public interface IComprasRepository
{
    Task CarregarSaldoAsync(Guid idCliente, decimal valor);

    Task ComprarAsync(Guid id, Guid clienteId, int quantidade, CancellationToken ct);

    Task<IEnumerable<ProdutoCliente>> HistoricoComprasAsync(CancellationToken ct);
}