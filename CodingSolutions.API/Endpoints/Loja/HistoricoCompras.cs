using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Loja;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Loja;

public class HistoricoCompras : EndpointWithoutRequest<IEnumerable<ComprasResponseDTO>>
{
    public override void Configure()
    {
        Get("loja/historico");
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var compras = await Resolve<IComprasRepository>().HistoricoComprasAsync(cancellationToken);
        await SendOkAsync(compras.Select(x => x.ToResponseDTO()), cancellationToken);
    }
}