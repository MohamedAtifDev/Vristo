using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;
using VristoAPI.Domain.Generic;

namespace VristoAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        [Key]
        
        public int ID { get; set; }


        [StringLength(100)]
        public string Name { get; set; }


        [StringLength(200)]
        public string? Description { get; set; }

       public int Quantity { get; set; }

        public double Price { get; set; }   


        public DateTime ExpirationDate { get; set; }


        [StringLength(20)]
        public string BarCode {  get; set; }


        public int CategoryID {  get; set; }


        [ForeignKey("CategoryID")]

        public ProductCategory Category { get; set; }

        public ICollection<CartProducts> cartProducts { get; set; }
        public ICollection<OrderProducts> orderProducts { get; set; }
    }
}
