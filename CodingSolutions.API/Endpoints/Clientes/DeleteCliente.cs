using CodingSolutions.API.Models;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

[HttpDelete("clientes/{id:guid}")]
public class DeleteCliente : Endpoint<IdFromRouteDTO>
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteCliente(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public override Task HandleAsync(IdFromRouteDTO req, CancellationToken ct)
    {
        _clienteRepository.Delete(req.Id);
        return Task.CompletedTask;
    }
}