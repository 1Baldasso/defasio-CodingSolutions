using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Cliente;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

[HttpGet("clientes")]
public class ListClientes : EndpointWithoutRequest<IEnumerable<ClienteResponseDTO>>
{
    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var clientes = await Resolve<IClienteRepository>().ListAllAsync(cancellationToken);
        await SendOkAsync(clientes.Select(x => x.ToResponseDTO()));
    }
}