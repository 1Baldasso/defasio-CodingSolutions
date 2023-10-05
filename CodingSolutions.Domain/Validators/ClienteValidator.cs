using FluentValidation;

namespace CodingSolutions.Domain.Validators;

public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(x => x.Nome)
        .NotEmpty()
            .WithMessage("O nome do cliente não pode ser vazio")
            .MaximumLength(100)
            .WithMessage("O nome do cliente não pode ter mais de 100 caracteres");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email do cliente não pode ser vazio")
            .EmailAddress()
            .WithMessage("O email do cliente não é válido");
        RuleFor(x => x.CPF)
            .NotEmpty()
            .WithMessage("O CPF do cliente não pode ser vazio")
            .Must(ValidaCPF)
            .WithMessage("O CPF do cliente não é válido");
    }

    private bool ValidaCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }
}