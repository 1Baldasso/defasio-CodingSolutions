using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;

namespace CodingSolutions.DataAccess;

public class ProdutoMockRepository : IProdutoRepository
{
    private static List<Produto> Produtos = new List<Produto>();

    public Task ComprarAsync(Guid id, Guid clienteId, CancellationToken ct)
    {
        Produtos.FirstOrDefault(x => x.Id == id).Clientes.Add(new Cliente() { Id = clienteId });
        return Task.CompletedTask;
    }

    public Task CreateAsync(Produto produto, CancellationToken ct = default)
    {
        produto.Id = Guid.NewGuid();
        produto.Clientes = new List<Cliente>();
        Produtos.Add(produto);
        return Task.CompletedTask;
    }

    public void Delete(Guid id)
    {
    }

    public Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return Task.FromResult(Produtos.FirstOrDefault(x => x.Id == id));
    }

    public Task<IEnumerable<Produto>> ListAllAsync(CancellationToken ct = default)
    {
        return Task.FromResult<IEnumerable<Produto>>(Produtos);
    }

    public Task UpdateAsync(Produto produto, CancellationToken ct = default)
    {
        return Task.CompletedTask;
    }
}