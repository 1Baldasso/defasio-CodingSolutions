using CodingSolutions.API.Models;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

[HttpDelete("clientes/{id:guid}")]
public class DeleteCliente : Endpoint<IdFromRouteDTO>
{
    public override async Task HandleAsync(IdFromRouteDTO req, CancellationToken ct)
    {
        await Resolve<IClienteRepository>().Delete(req.Id);
    }
}