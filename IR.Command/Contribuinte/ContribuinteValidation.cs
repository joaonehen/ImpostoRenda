using FluentValidation;
using IR.Command.CustomValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command
{
    public abstract class ContribuinteValidation<T> : AbstractValidator<T> where T : ContribuinteCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O Id deve ser informado.")
                .IsGuid();
        }

        protected void ValidateCpf()
        {
            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("O CPF deve ser informado.")
                .Length(14).WithMessage("O tamanho do CPF é inválido")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$").WithMessage("O formato do CPF é inválido")
                .IsCpf();
        }

        protected void ValidateNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome deve ser informado.")
                .Length(3, 200).WithMessage("O Nome deve ter entre 3 e 200 caracteres.");
        }

        protected void ValidateNumeroDependentes()
        {
            RuleFor(x => x.NumeroDependentes)
                .GreaterThanOrEqualTo(0).WithMessage("O numero de dependentes deve ser maior ou igual a zero.");
        }

        protected void ValidateRendaBrutaMensal()
        {
            RuleFor(x => x.RendaBrutaMensal)
                .GreaterThanOrEqualTo(0).WithMessage("O valor da renda bruta mensal deve ser maior ou igual a zero.");
        }
    }
}
