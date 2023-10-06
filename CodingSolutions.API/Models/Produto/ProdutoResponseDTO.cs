namespace CodingSolutions.API.Models.Produto;

public record ProdutoResponseDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public ICollection<Comprador> Compradores { get; set; }
}

public record Comprador(string Nome, int Quantidade);