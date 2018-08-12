using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Domain.Entity
{
    public class AliquotaImpostoRenda
    {
        private readonly decimal _percentual;
        private readonly int _quantidadeSalariosMinimos;
        private AliquotaImpostoRenda _proximaAliquotaImpostoRenda;

        public AliquotaImpostoRenda(decimal percentual, int quantidadeSalariosMinimos)
        {
            _percentual = percentual;
            _quantidadeSalariosMinimos = quantidadeSalariosMinimos;
        }

        public AliquotaImpostoRenda(decimal percentual) : this(percentual, int.MaxValue)
        {

        }

        public AliquotaImpostoRenda SendoProxima(AliquotaImpostoRenda proximaAliquotaImpostoRenda)
        {
            _proximaAliquotaImpostoRenda = proximaAliquotaImpostoRenda;
            return this;
        }

        public decimal ObterValorImpostoRenda(decimal salarioMinimo, decimal rendaLiquida)
        {
            if ((rendaLiquida / salarioMinimo) > _quantidadeSalariosMinimos)
                return _proximaAliquotaImpostoRenda?.ObterValorImpostoRenda(salarioMinimo, rendaLiquida) ?? 0m;
            return CalcularValorImpostoRenda(rendaLiquida);
        }

        private decimal CalcularValorImpostoRenda(decimal rendaLiquida)
        {
            return (_percentual / 100) * rendaLiquida;
        }
    }
}
