using CodingSolutions.API.Models;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpDelete("produtos/{id:guid}")]
public class DeleteProduto : Endpoint<IdFromRouteDTO>
{
    public override async Task HandleAsync(IdFromRouteDTO request, CancellationToken cancellationToken)
    {
        await Resolve<IProdutoRepository>().Delete(request.Id);
        await SendOkAsync("Produto deletado com sucesso");
    }
}