using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

[HttpGet("clientes")]
public class ListClientes : EndpointWithoutRequest<IEnumerable<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public ListClientes(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var clientes = await _clienteRepository.ListAllAsync(cancellationToken);
        await SendOkAsync(clientes);
    }
}