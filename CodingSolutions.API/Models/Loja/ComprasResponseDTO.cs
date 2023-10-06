namespace CodingSolutions.API.Models.Loja;

public class ComprasResponseDTO
{
    public Guid Id { get; set; }
    public string NomeCliente { get; set; }
    public string NomeProduto { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public decimal? ValorTotal { get; set; }
}