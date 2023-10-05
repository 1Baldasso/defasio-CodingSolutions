using CodingSolutions.API.Models;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpGet("produtos/{id:guid}")]
public class GetProduto : Endpoint<IdFromRouteDTO>
{
    private readonly IProdutoRepository _repository;

    public GetProduto(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(IdFromRouteDTO request, CancellationToken cancellationToken)
    {
        var produto = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (produto == null)
        {
            await SendNotFoundAsync(cancellationToken);
        }
        await SendOkAsync(produto, cancellationToken);
    }
}