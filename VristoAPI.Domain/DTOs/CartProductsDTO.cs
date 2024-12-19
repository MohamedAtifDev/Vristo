using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.DTOs
{
    public class CartProductsDTO
    {
        public int CartID { get; set; }

        public int ProductID { get; set; }

        public ProductDTO Product { get; set; }

        public int Quantity { get; set; }
        public CartDTO Cart { get; set; }
    }
}
