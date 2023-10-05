using Microsoft.AspNetCore.Mvc;

namespace CodingSolutions.API.Models;

public record IdFromRouteDTO
{
    [FromRoute]
    public Guid Id { get; init; }
}