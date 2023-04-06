using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DA.Repository.IRepository
{
    // Where T is any class imolementing it.
    // can be used for any class where T will represent the class
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);

        T GetFirstOrDefalut(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
    }
    
}
