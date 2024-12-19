using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VristoAPI.Domain.Entities
{
    public  class CartProducts
    {
        public int CartID { get; set; }

        public int ProductID { get; set; }


        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        [ForeignKey(nameof(CartID))]
        public Cart Cart { get; set; }  


        public int Quantity {  get; set; }
    }
}
