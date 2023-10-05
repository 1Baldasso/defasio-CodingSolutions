using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpPut("produtos/{id:guid}")]
public class UpdateProduto : Endpoint<ProdutoUpdateDTO>
{
    private readonly IProdutoRepository _repository;

    public UpdateProduto(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(ProdutoUpdateDTO request, CancellationToken cancellationToken = default)
    {
        await _repository.UpdateAsync(request.ToEntity<ProdutoUpdateDTO, Produto>(), cancellationToken);
        await SendOkAsync("Produto atualizado com sucesso", cancellationToken);
    }
}