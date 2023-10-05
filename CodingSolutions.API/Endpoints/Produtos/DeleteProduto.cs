using CodingSolutions.API.Models;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpDelete("produtos/{id:guid}")]
public class DeleteProduto : Endpoint<IdFromRouteDTO>
{
    private readonly IProdutoRepository _repository;

    public DeleteProduto(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(IdFromRouteDTO request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.Id);
        await SendOkAsync("Produto deletado com sucesso");
    }
}