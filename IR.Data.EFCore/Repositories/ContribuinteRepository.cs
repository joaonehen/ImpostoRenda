using IR.Data.EFCore.Context;
using IR.Domain.Entity;
using IR.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IR.Data.EFCore.Repositories
{
    public class ContribuinteRepository : Repository<Contribuinte>, IContribuinteRepository
    {
        public ContribuinteRepository(IRContext context) : base(context)
        {
        }

        public bool IsCpfRegistered(string cpf)
        {
            return Set.Any(x => x.CPF == cpf);
        }
    }
}
