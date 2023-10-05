using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpPost("produtos")]
public class CreateProduto : Endpoint<ProdutoCreateDTO>
{
    private readonly IProdutoRepository _repository;

    public CreateProduto(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(ProdutoCreateDTO request, CancellationToken cancellationToken)
    {
        request.Id = Guid.NewGuid();
        await _repository.CreateAsync(request.ToEntity<ProdutoCreateDTO, Produto>(), cancellationToken);
        await SendCreatedAtAsync<ListProdutos>(null, "Produto Criado com sucesso");
    }
}