namespace CodingSolutions.Domain;

public record Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public virtual ICollection<Cliente> Clientes { get; set; }
}