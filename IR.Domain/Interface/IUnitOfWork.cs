using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
