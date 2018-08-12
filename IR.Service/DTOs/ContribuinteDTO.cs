using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Service.DTOs
{
    public class ContribuinteDTO
    {
        public string Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public int NumeroDependentes { get; set; }
        public decimal RendaBrutaMensal { get; set; }
        public decimal ValorImpostoRenda { get; set; }
    }
}
