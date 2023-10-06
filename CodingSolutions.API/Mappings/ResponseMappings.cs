using CodingSolutions.API.Models.Cliente;
using CodingSolutions.API.Models.Loja;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain;
using System.Runtime.CompilerServices;

namespace CodingSolutions.API.Mappings;

public static class ResponseMappings
{
    public static ClienteResponseDTO ToResponseDTO(this Cliente cliente)
    {
        return new ClienteResponseDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            CPF = cliente.CPF,
            Produtos = cliente.ProdutoPorCliente.Select(x => new ProdutoComprado(x.Produto.Nome, x.Quantidade)).ToList()
        };
    }

    public static ProdutoResponseDTO ToResponseDTO(this Produto produto)
    {
        return new ProdutoResponseDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco,
            Compradores = produto.ProdutoPorCliente.Select(x => new Comprador(x.Cliente.Nome, x.Quantidade)).ToList()
        };
    }

    public static ComprasResponseDTO ToResponseDTO(this ProdutoCliente produtosPorCliente)
    {
        return new ComprasResponseDTO
        {
            Id = produtosPorCliente.Id,
            NomeCliente = produtosPorCliente.Cliente.Nome,
            NomeProduto = produtosPorCliente.Produto.Nome,
            Quantidade = produtosPorCliente.Quantidade,
            Valor = produtosPorCliente.Produto.Preco,
            ValorTotal = produtosPorCliente.Produto.Preco * produtosPorCliente.Quantidade,
        };
    }
}