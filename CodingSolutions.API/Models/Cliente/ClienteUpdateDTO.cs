using CodingSolutions.Domain;
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
    public new ICollection<ProdutoCliente> ProdutoPorCliente { get; set; }
}