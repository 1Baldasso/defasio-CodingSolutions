namespace CodingSolutions.API.Models.Cliente;

public record ClienteResponseDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public decimal Saldo { get; set; }
    public ICollection<ProdutoComprado> Produtos { get; set; }
}

public record ProdutoComprado(string Produto, int Quantidade);