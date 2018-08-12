using IR.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Domain.Interface
{
    public interface IRepository<TEntity> where TEntity : EntidadeBase
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
