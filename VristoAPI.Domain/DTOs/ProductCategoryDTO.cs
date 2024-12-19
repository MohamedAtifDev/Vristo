using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.DTOs
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public CartDTO Cart { get; set; }
    }
}
