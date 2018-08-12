using IR.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Domain.Interface
{
    public interface IContribuinteRepository : IRepository<Contribuinte>
    {
        bool IsCpfRegistered(string cpf);
    }
}
