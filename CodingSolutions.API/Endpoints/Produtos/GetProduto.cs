using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpGet("produtos/{id:guid}")]
public class GetProduto : Endpoint<IdFromRouteDTO, ProdutoResponseDTO>
{
    public override async Task HandleAsync(IdFromRouteDTO request, CancellationToken cancellationToken)
    {
        var produto = await Resolve<IProdutoRepository>().GetByIdAsync(request.Id, cancellationToken);
        if (produto == null)
        {
            await SendNotFoundAsync(cancellationToken);
        }
        await SendOkAsync(produto.ToResponseDTO(), cancellationToken);
    }
}