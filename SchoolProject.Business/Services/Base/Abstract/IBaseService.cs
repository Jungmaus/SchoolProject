using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Business.Services.Base.Abstract
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        List<T> GetAllWithQuery(Expression<Func<T, bool>> lambda);

        T Insert(T entity);
        T Update(T entity);
        bool Delete(int? id);

        T FirstOrDefault(Expression<Func<T, bool>> lambda);
    }
}
