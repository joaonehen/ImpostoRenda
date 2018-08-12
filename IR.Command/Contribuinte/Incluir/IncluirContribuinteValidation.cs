using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command
{
    public class IncluirContribuinteValidation : ContribuinteValidation<IncluirContribuinteCommand>
    {
        public IncluirContribuinteValidation()
        {
            ValidateCpf();
            ValidateNome();
            ValidateNumeroDependentes();
            ValidateRendaBrutaMensal();
        }
    }
}
