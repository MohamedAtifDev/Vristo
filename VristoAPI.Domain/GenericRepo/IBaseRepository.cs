using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Domain.GenericRepo
{
    public interface IBaseRepository<T> where T:class
    {
       IEnumerable<T> GetAll();
        T GetByID(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

      IEnumerable<T> Filter(Func<T, bool> predicate);

    void AddRange(IEnumerable<T> entities);

    void DeleteRange(int[] ids);

        int Count();
        int Save();


    }
}
