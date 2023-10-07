using CodingSolutions.Domain;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Text.Json.Serialization;

namespace CodingSolutions.API.Models.Produto;

public record ProdutoUpdateDTO
{
    [FromRoute]
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public decimal Preco { get; set; } = 0;
}