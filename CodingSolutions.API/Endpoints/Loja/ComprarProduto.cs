using CodingSolutions.API.Models;
using CodingSolutions.API.Models.Loja;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Loja;

public class ComprarProduto : Endpoint<ComprarProdutoDTO>
{
    public override void Configure()
    {
        Post("loja/produtos/comprar");
    }

    public override async Task HandleAsync(ComprarProdutoDTO req, CancellationToken ct)
    {
        await Resolve<IProdutoRepository>().ComprarAsync(req.ProdutoId, req.ClienteId, ct);
        await SendOkAsync($"Produto {req.ProdutoId} comprado com sucesso");
    }
}