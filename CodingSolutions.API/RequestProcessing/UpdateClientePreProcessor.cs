using CodingSolutions.API.Mappings;
using CodingSolutions.API.Models.Cliente;
using CodingSolutions.Domain.Transformations;
using CodingSolutions.Domain.Validators;
using FastEndpoints;
using FluentValidation.Results;

namespace CodingSolutions.API.RequestProcessing;

public class UpdateClientePreProcessor : IPreProcessor<ClienteUpdateDTO>
{
    public async Task PreProcessAsync(ClienteUpdateDTO req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        var vr = await new ClienteValidator().ValidateAsync(req.ToEntity().TransformClienteData(), ct);
        if (!vr.IsValid)
        {
            failures.AddRange(vr.Errors);
            await ctx.Response.SendErrorsAsync(failures);
        }
    }
}