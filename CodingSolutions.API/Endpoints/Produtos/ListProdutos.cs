using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpGet("produtos")]
public class ListProdutos : EndpointWithoutRequest<IEnumerable<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public ListProdutos(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var produtos = await _produtoRepository.ListAllAsync(cancellationToken);
        await SendOkAsync(produtos, cancellationToken);
    }
}