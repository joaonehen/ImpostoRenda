using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command
{
    public class IncluirContribuinteCommand : ContribuinteCommand
    {
        public IncluirContribuinteCommand(string cpf, string nome, int numeroDependentes, decimal rendaBrutaMensal)
        {
            CPF = cpf;
            Nome = nome;
            NumeroDependentes = numeroDependentes;
            RendaBrutaMensal = rendaBrutaMensal;
        }

        public override bool IsValid()
        {
            ValidationResult = new IncluirContribuinteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
