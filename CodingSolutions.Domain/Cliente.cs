namespace CodingSolutions.Domain;

public record Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public virtual ICollection<ProdutoCliente> ProdutoPorCliente { get; set; }
}