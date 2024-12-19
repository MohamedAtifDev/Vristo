using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;
using VristoAPI.Domain.GenericRepo;
using VristoAPI.Domain.UnitOfWork;
using VristoAPI.Infrastructure.Database;

namespace VristoAPI.Infrastructure.UnitOfWork
{
    public class UnitOfWork(DataContext db) : IUnitOfWork
    {
        public IBaseRepository<Product> Products => new BaseRepoistory<Product>(db);

        public int Complete()
        {
           return Products.Save();
        }
    }
}
