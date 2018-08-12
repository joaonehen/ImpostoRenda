using IR.Data.EFCore.Context;
using IR.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Data.EFCore.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRContext _context;

        public UnitOfWork(IRContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
