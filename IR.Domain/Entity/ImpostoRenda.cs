using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Domain.Entity
{
    public class ImpostoRenda
    {
        private readonly decimal _percentualDescontoPorDependente;
        private readonly AliquotaImpostoRenda _aliquota;
        private readonly decimal _salarioMinimo;

        public ImpostoRenda(decimal salarioMinimo)
        {
            _salarioMinimo = salarioMinimo;
            _percentualDescontoPorDependente = 5;
            _aliquota = new AliquotaImpostoRenda(0, 2)
                .SendoProxima(new AliquotaImpostoRenda(7.5m, 4)
                .SendoProxima(new AliquotaImpostoRenda(15, 5)
                .SendoProxima(new AliquotaImpostoRenda(22.5m, 7)
                .SendoProxima(new AliquotaImpostoRenda(27.5m)))));
        }

        public void CalcularImpostoRendaContribuinte(Contribuinte contribuinte)
        {
            var valorDesconto = ((contribuinte.NumeroDependentes * _percentualDescontoPorDependente) / 100) * _salarioMinimo;
            var rendaLiquida = contribuinte.RendaBrutaMensal - valorDesconto;
            contribuinte.ValorImpostoRenda = _aliquota.ObterValorImpostoRenda(_salarioMinimo, rendaLiquida);
        }
    }
}
