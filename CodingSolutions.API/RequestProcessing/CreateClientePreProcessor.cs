using CodingSolutions.API.Models.Cliente;
using CodingSolutions.Domain.Validators;
using FastEndpoints;
using FluentValidation.Results;

namespace CodingSolutions.API.RequestProcessing;

public class CreateClientePreProcessor : IPreProcessor<ClienteCreateDTO>
{
    public async Task PreProcessAsync(ClienteCreateDTO req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        var vr = await new ClienteValidator().ValidateAsync(req);
        if (!vr.IsValid)
        {
            failures.AddRange(vr.Errors);
            await ctx.Response.SendErrorsAsync(failures);
        }
    }
}