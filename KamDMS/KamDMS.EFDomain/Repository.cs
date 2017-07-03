using KamDMS.DaoContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.EFDomain
{
    public class Repository<TEntity> : IDaoHandler<TEntity>, IDisposable
            where TEntity : class, new()
    {
        private readonly AppContext context;

        private readonly DbSet<TEntity> dbSet;

        public Repository(AppContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get
        {
            get
            {
                return dbSet;
            }
        }

        public TEntity GetById(string id)
        {
            TEntity entry = dbSet.Find(id);

            if (entry == null)
            {
                return null;
            }

            return entry;
        }

        public bool Delete(string id)
        {
            TEntity entry = GetById(id);

            if (entry == null)
            {
                return false;
            }

            Delete(entry);
            return true;
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
            context.SaveChanges();
            return true;
        }

        public bool Add(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            dbSet.Add(entity);
            context.SaveChanges();
            return true;
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }


        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
