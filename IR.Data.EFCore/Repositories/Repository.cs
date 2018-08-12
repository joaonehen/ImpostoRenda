using IR.Data.EFCore.Context;
using IR.Domain.Entity;
using IR.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IR.Data.EFCore.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        protected readonly IRContext Context;
        protected readonly DbSet<T> Set;

        public Repository(IRContext context)
        {
            Context = context;
            Set = Context.Set<T>();
        }

        public void Add(T obj)
        {
            obj.Created = DateTime.Now;
            Set.Add(obj);
        }

        public List<T> GetAll()
        {
            return Set.ToList();
        }

        public T GetById(Guid id)
        {
            return Set.Find(id);
        }

        public void Remove(Guid id)
        {
            Set.Remove(GetById(id));
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Update(T obj)
        {
            obj.Updated = DateTime.Now;
            Set.Update(obj);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
