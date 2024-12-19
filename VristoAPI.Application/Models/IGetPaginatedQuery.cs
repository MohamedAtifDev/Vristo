using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VristoAPI.Application.DTOs
{
    public  class IGetPaginatedQuery
    {
        public string Serach { get; set; } = "";
        public string SortBy { get; set; }= "";

        public string SortOrder { get; set; } = "";

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
