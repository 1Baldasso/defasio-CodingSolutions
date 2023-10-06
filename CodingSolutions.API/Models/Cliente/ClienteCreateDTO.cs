using CodingSolutions.Domain;
using NSwag.Annotations;
using System.Text.Json.Serialization;

namespace CodingSolutions.API.Models.Cliente;

public record ClienteCreateDTO : Domain.Cliente
{
    [OpenApiIgnore, JsonIgnore]
    public new Guid Id { get; set; }

    [OpenApiIgnore, JsonIgnore]
    public new ICollection<ProdutoCliente> ProdutoPorCliente { get; set; }
}