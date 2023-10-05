using Humanizer;

namespace CodingSolutions.Domain.Transformations;

public static class DataTransformations
{
    public static Cliente TransformClienteData(this Cliente cliente)
    {
        cliente.Nome = cliente.Nome.Titleize();
        cliente.Email = cliente.Email.ToLower();
        cliente.CPF.Replace(".", "").Replace("-", "").Trim();
        return cliente;
    }

    public static Produto TransformProdutoData(this Produto produto)
    {
        produto.Nome.Titleize();
        produto.Descricao.Transform(To.SentenceCase);
        produto.Preco = Math.Round(produto.Preco, 2);
        return produto;
    }
}