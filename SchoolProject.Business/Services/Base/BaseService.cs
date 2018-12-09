using SchoolProject.Data.Context;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Business.Services.Base.Abstract
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected DatabaseContext db;
        protected DbSet<TEntity> dbcontext;
        protected ServiceProvider Services;

        public BaseService()
        {
            db = new DatabaseContext();
            dbcontext = db.Set<TEntity>();
            Services = new ServiceProvider();
        }

        public bool Delete(int? id)
        {
            if (id != null)
            {
                var entity = dbcontext.Find(id);
                entity.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> lambda) => dbcontext.Where(x => !x.IsDeleted).FirstOrDefault(lambda);

        public List<TEntity> GetAll() => dbcontext.Where(x => x.IsDeleted == false).ToList();

        public List<TEntity> GetAllWithQuery(Expression<Func<TEntity, bool>> lambda) => dbcontext.Where(x => x.IsDeleted == false).Where(lambda).ToList();

        public TEntity Insert(TEntity entity)
        {
            if (entity != null)
            {
                entity.IsDeleted = false;
                dbcontext.Add(entity);
                db.SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entity = dbcontext.Find(entity.ID);
                entity.IsDeleted = _entity.IsDeleted;
                db.Entry(_entity).CurrentValues.SetValues(entity);
                db.SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public void Dispose()
        {
            Services.Dispose();
            db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
