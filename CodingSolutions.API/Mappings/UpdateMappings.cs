using CodingSolutions.API.Models.Cliente;
using CodingSolutions.API.Models.Produto;
using CodingSolutions.Domain;

namespace CodingSolutions.API.Mappings;

public static class UpdateMappings
{
    public static Cliente ToEntity(this ClienteUpdateDTO dto)
    {
        return new Cliente
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Email = dto.Email,
            CPF = dto.CPF
        };
    }

    public static Produto ToEntity(this ProdutoUpdateDTO dto)
    {
        return new Produto
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Preco = dto.Preco,
        };
    }
}