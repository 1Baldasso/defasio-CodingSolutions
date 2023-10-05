using CodingSolutions.API.Models;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

[HttpGet("clientes/{id:guid}")]
public class GetCliente : Endpoint<IdFromRouteDTO>
{
    private readonly IClienteRepository _repository;

    public GetCliente(IClienteRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(IdFromRouteDTO req, CancellationToken ct)
    {
        var produto = await _repository.GetByIdAsync(req.Id, ct);
        if (produto == null)
        {
            await SendNotFoundAsync(ct);
        }
        await SendOkAsync(produto);
    }
}