using FluentValidation;

namespace CodingSolutions.Domain.Validators;

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do produto não pode ser vazio")
            .MaximumLength(100)
            .WithMessage("O nome do produto não pode ter mais de 100 caracteres");
        RuleFor(x => x.Preco)
            .NotEmpty()
            .WithMessage("O preço do produto não pode ser vazio")
            .GreaterThan(0)
            .WithMessage("O preço do produto deve ser maior que zero");
        RuleFor(x => x.Descricao)
            .MaximumLength(244)
            .WithMessage("Descrição não deve ter mais de 244 caracters");
    }
}