using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Cliente;
using CodingSolutions.API.RequestProcessing;
using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Clientes;

public class UpdateCliente : Endpoint<ClienteUpdateDTO>
{
    public override void Configure()
    {
        Put("clientes/{id:guid}");
        PreProcessors(new UpdateClientePreProcessor());
    }

    public override async Task HandleAsync(ClienteUpdateDTO req, CancellationToken ct)
    {
        await Resolve<IClienteRepository>().UpdateAsync(req.ToEntity<ClienteUpdateDTO, Cliente>(), ct);
        await SendOkAsync("Cliente atualizado com sucesso");
    }
}