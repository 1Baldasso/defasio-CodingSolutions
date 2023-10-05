using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace CodingSolutions.API.Models.Loja;

public record ComprarProdutoDTO
{
    public Guid ProdutoId { get; init; }
    public Guid ClienteId { get; init; }
}