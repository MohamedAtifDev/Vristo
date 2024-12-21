using Microsoft.EntityFrameworkCore;

using VristoAPI.Infrastructure.Database;

namespace VristoAPI.Domain.GenericRepo
{
    public class BaseRepoistory<T>(DataContext db) : IBaseRepository<T> where T : class
    {
        public void Add(T entity)
        {
             db.Set<T>().Add(entity);

                }

        public void AddRange(IEnumerable<T> entities)
        {
            db.Set<T>().AddRange(entities);
        }

        public int Count()
        {
          return db.Set<T>().Count();
        }

        public void Delete(int id)
        {
            db.Set<T>().Remove(db.Set<T>().Find(id));
        }

        public void DeleteRange(int[] ids)
        {
            db.Set<T>().RemoveRange(db.Set<T>().Find(ids));
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
         return db.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsNoTracking().ToList();
        }

        public T GetByID(int id)
        {
            return    db.Set<T>().Find(id);
        }

        public int Save()
        {
           return  db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Set<T>().Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
