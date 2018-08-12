using IR.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Data.EFCore.Mapping
{
    public class ContribuinteMap : EntidadeBaseMap<Contribuinte>
    {
        public override void Configure(EntityTypeBuilder<Contribuinte> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CPF);
            builder.Property(x => x.Nome);
            builder.Property(x => x.NumeroDependentes);
            builder.Property(x => x.RendaBrutaMensal);
            builder.Ignore(x => x.ValorImpostoRenda);
        }

    }
}
