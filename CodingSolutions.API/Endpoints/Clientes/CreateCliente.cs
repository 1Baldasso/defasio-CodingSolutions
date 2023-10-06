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

    public override async Task HandleAsync(ClienteCreateDTO req, CancellationToken ct)
    {
        await Resolve<IClienteRepository>().CreateAsync(req.ToEntity<ClienteCreateDTO, Cliente>(), ct);
        await SendCreatedAtAsync<ListClientes>(null, "Cliente criado com sucesso");
    }
}