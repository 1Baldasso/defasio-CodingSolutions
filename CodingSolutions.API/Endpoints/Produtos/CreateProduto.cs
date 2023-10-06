using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using CodingSolutions.Domain.Transformations;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpPost("produtos")]
public class CreateProduto : Endpoint<ProdutoCreateDTO>
{
    public override async Task HandleAsync(ProdutoCreateDTO request, CancellationToken cancellationToken)
    {
        request.Id = Guid.NewGuid();
        await Resolve<IProdutoRepository>().CreateAsync(
            request.ToEntity<ProdutoCreateDTO, Produto>()
                .TransformProdutoData(),
            cancellationToken
            );
        await SendCreatedAtAsync<ListProdutos>(null, "Produto Criado com sucesso");
    }
}