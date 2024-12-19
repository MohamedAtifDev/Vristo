using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;


namespace VristoAPI.Application.DTOs
{
    public class ProductDTO
    {
   

        public Guid ID { get; set; }


        public string Name { get; set; }


        public string? Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }


        public DateTime ExpirationDate { get; set; }


        public string BarCode { get; set; }


        public Guid CategoryID { get; set; }


        //[ForeignKey("CategoryID")]

        //public ProductCategory Category { get; set; }

        //public ICollection<CartProducts> cartProducts { get; set; }
        //public ICollection<OrderProducts> orderProducts { get; set; }
    }
}
