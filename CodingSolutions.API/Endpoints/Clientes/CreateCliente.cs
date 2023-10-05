using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Cliente;
using CodingSolutions.API.RequestProcessing;
using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

public class CreateCliente : Endpoint<ClienteCreateDTO>
{
    public override void Configure()
    {
        Post("clientes");
        PreProcessors(new CreateClientePreProcessor());
    }

    private readonly IClienteRepository _repository;

    public CreateCliente(IClienteRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(ClienteCreateDTO req, CancellationToken ct)
    {
        await _repository.CreateAsync(req.ToEntity<ClienteCreateDTO, Cliente>(), ct);
        await SendCreatedAtAsync<ListClientes>(null, "Cliente criado com sucesso");
    }
}