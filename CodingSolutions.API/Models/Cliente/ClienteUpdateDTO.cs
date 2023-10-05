using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Text.Json.Serialization;

namespace CodingSolutions.API.Models.Cliente;

public record ClienteUpdateDTO : Domain.Cliente
{
    [FromRoute]
    [OpenApiIgnore, JsonIgnore]
    public new Guid Id { get; set; }
    [OpenApiIgnore, JsonIgnore]
    public new ICollection<Domain.Produto> Produtos { get; set; }
}