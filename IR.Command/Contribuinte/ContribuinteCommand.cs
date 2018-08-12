using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command
{
    public abstract class ContribuinteCommand : Command
    {
        public string Id { get; protected set; }
        public string CPF { get; protected set; }
        public string Nome { get; protected set; }
        public int NumeroDependentes { get; protected set; }
        public decimal RendaBrutaMensal { get; protected set; }
    }
}
