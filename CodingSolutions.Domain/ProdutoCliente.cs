namespace CodingSolutions.Domain;

public class ProdutoCliente
{
    public virtual Cliente Cliente { get; set; }
    public virtual Produto Produto { get; set; }
    public int Quantidade { get; set; }
}