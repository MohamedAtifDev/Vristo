using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;
using VristoAPI.Domain.GenericRepo;

namespace VristoAPI.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBaseRepository<Product> Products { get; }
        int Complete();
        
    }
}
