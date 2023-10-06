using CodingSolutions.API.Models.Loja;
using CodingSolutions.Domain.Repositories;
using FastEndpoints;

namespace CodingSolutions.API.Endpoints.Loja;

public class CarregarSaldo : Endpoint<CarregarSaldoDTO>
{
    public override void Configure()
    {
        Put("/loja/carregar-saldo");
    }

    public override async Task HandleAsync(CarregarSaldoDTO request, CancellationToken cancellationToken)
    {
        await Resolve<IComprasRepository>().CarregarSaldoAsync(request.IdCliente, request.Valor);
        await SendOkAsync("Saldo Carregado com Sucesso");
    }
}