using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class DAO<T> where T : BaseModel, IDisposable
    {
        protected readonly LojaContexto  context;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet;

        public DAO(LojaContexto context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T p)
        {
            dbSet.Add(p);
        }

        public void Update(T p)
        {
            dbSet.Update(p);
        }

        public void Remove(T  p)
        {
            dbSet.Remove(p);
        }

        public IList<T> List(T p)
        {
            return dbSet.ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
