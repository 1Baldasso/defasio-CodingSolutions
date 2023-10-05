using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Text.Json.Serialization;

namespace CodingSolutions.API.Models.Produto;

public record ProdutoUpdateDTO : Domain.Produto
{
    [FromRoute]
    [OpenApiIgnore, JsonIgnore]
    public new Guid Id { get; set; }

    [OpenApiIgnore, JsonIgnore]
    public new ICollection<Domain.Cliente> Clientes { get; set; }
}