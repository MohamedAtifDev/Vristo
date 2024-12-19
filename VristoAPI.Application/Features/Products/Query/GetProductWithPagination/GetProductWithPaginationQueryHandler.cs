using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VristoAPI.Domain.DTOs;
using VristoAPI.Domain.Models;
using VristoAPI.Domain.UnitOfWork;
using VristoAPI.Infrastructure.Database;

namespace VristoAPI.Application.Features.Products.Query.GetProductWithPagination
{
    public class GetProductWithPaginationQueryHandler : IRequestHandler<GetProductWithPaginationQuery,PaginatedList<ProductDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProductWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task <PaginatedList<ProductDTO>> Handle(GetProductWithPaginationQuery request, CancellationToken cancellationToken)
        {

            var data = unitOfWork.Products.GetAll();
         
            var result = mapper.Map<List<ProductDTO>>(data);
            var x= await PaginatedList<ProductDTO>.CreateAsync
                (result, request.Page, request.PageSize);
            return x;

        }
    }
}
