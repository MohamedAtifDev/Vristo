using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.DTOs
{
    public class OrderProductsDTO
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public ProductDTO Product { get; set; }

  
        public OrderDTO Order { get; set; }
    }
}
