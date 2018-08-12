using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Domain.Entity
{
    public class Contribuinte : EntidadeBase
    {
        public Contribuinte(string cpf, string nome, int numeroDependentes, decimal rendaBrutaMensal)
        {
            Id = new Guid();
            CPF = cpf;
            Nome = nome;
            NumeroDependentes = numeroDependentes;
            RendaBrutaMensal = rendaBrutaMensal;
        }

        protected Contribuinte() { }

        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public int NumeroDependentes { get; private set; }
        public decimal RendaBrutaMensal { get; private set; }
        public decimal ValorImpostoRenda { get; set; }
    }
}
