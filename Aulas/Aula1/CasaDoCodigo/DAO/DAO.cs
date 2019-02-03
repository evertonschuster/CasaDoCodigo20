using CasaDoCodigo.Models;
using CasaDoCodigo.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class DAO<T> : IDAO, IDisposable where T : BaseModel, IDisposable 
    {
        protected readonly LojaContexto context;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet;
        protected readonly Session Session;
        
        public LojaContexto GetContext()
        {
            return this.context;
        }

        public Session GetSssion()
        {
            return this.Session;
        }
        public DAO(LojaContexto context, Session session )
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this.Session = session;

            context.Database.EnsureCreated();
        }

        public DAO(IDAO dao)
        {
            this.context = dao.GetContext();
            this.dbSet = this.context.Set<T>();
            this.Session = dao.GetSssion();

            context.Database.EnsureCreated();
        }

        public virtual void Add(T p)
        {
            dbSet.Add(p);
        }

        public virtual void Update(T p)
        {
            dbSet.Update(p);
        }

        public virtual void Remove(T  p)
        {
            dbSet.Remove(p);
        }

        public virtual IList<T> List(T p)
        {
            return dbSet.ToList();
        }

        public virtual T getById(T p)
        {
            return dbSet.Where(i => i.Id == p.Id).FirstOrDefault();
        }

        public virtual IList<T> List()
        {
            return dbSet.ToList();
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }


    }
}
