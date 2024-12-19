using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Domain.Models
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
         public List<T> Items { get; private set; }
        public int PageSize {  get; private set; }
        public bool HasNextPage { get; private set; }
        public bool HasPreviousPage { get; private set; }

        
         public PaginatedList(List<T> items, int Page, int count, int PageSize)
        {
            this.Items = items;
            this.TotalPages = count;
            this.PageSize = PageSize;
            this.PageIndex = Page;
            this.HasNextPage = this.PageIndex < count;
            this.HasPreviousPage = this.PageIndex > 1;
        
        }
        public static async Task<PaginatedList<T>> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items,
               pageIndex,
                  count,
                  pageSize
                 
                  
  );
        }

    }
}
