using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using CodingSolutions.Domain.Transformations;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Produtos;

[HttpPut("produtos/{id:guid}")]
public class UpdateProduto : Endpoint<ProdutoUpdateDTO>
{
    public override async Task HandleAsync(ProdutoUpdateDTO request, CancellationToken cancellationToken = default)
    {
        await Resolve<IProdutoRepository>().UpdateAsync(
            request.ToEntity()
                .TransformProdutoData(),
            cancellationToken
            );
        await SendOkAsync("Produto atualizado com sucesso", cancellationToken);
    }
}