using NSwag.Annotations;
using System.Text.Json.Serialization;

namespace CodingSolutions.API.Models.Cliente;

public record ClienteCreateDTO : Domain.Cliente
{
    [OpenApiIgnore, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public new Guid Id { get; set; }

    [OpenApiIgnore, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public new ICollection<Domain.Produto> Produtos { get; set; }
}