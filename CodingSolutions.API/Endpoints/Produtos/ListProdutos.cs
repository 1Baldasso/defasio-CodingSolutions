using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpGet("produtos")]
public class ListProdutos : EndpointWithoutRequest<IEnumerable<ProdutoResponseDTO>>
{
    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var produtos = await Resolve<IProdutoRepository>().ListAllAsync(cancellationToken);
        await SendOkAsync(produtos.Select(x => x.ToResponseDTO()), cancellationToken);
    }
}