using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Linq.Expressions;

namespace PandaDataAccessLayer.DAL
{
    public class DAL<TDbContext> : IDisposable where TDbContext : DbContext, new()
    {
        TDbContext mDbContext;

        public TDbContext DbContext 
        {
            get { return mDbContext; } 
        }

        public DAL() 
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
            mDbContext = new TDbContext();
        }

        public TEntity GetById<TEntity>(Guid id) where TEntity : class, IGuidIdentifiable
        {
            return mDbContext.Set<TEntity>().Single(x => x.Id == id);
        }

        public void DeleteById<TEntity>(Guid id) where TEntity : class, IGuidIdentifiable
        {
            mDbContext.Set<TEntity>().Remove(GetById<TEntity>(id));
        }

        public void UpdateById<TEntity>(Guid id, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class, IGuidIdentifiable
        {
            mDbContext.Set<TEntity>().Update(x => x.Id == id, updateExpression);
        }

        public TEntity Create<TEntity>() where TEntity : class
        {
            var set = mDbContext.Set<TEntity>();
            var instance = set.Create();
            set.Add(instance);
            return instance;
        }



        public void Dispose()
        {
            if (mDbContext != null)
                mDbContext.Dispose();
            mDbContext = null;
        }
    }
}
