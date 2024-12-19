using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

using VristoAPI.Domain.Models;
using VristoAPI.Domain.DTOs;
namespace VristoAPI.Application.Features.Products.Query.GetProductWithPagination
{
    public class GetProductWithPaginationQuery: IGetPaginatedQuery,IRequest<PaginatedList<ProductDTO>>
    {
       
    }
}
