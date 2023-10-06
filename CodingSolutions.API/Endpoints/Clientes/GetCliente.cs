using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models;
using CodingSolutions.API.Models.Cliente;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

[HttpGet("clientes/{id:guid}")]
public class GetCliente : Endpoint<IdFromRouteDTO, ClienteResponseDTO>
{
    public override async Task HandleAsync(IdFromRouteDTO req, CancellationToken ct)
    {
        var produto = await Resolve<IClienteRepository>().GetByIdAsync(req.Id, ct);
        if (produto == null)
        {
            await SendNotFoundAsync(ct);
        }
        await SendOkAsync(produto.ToResponseDTO());
    }
}