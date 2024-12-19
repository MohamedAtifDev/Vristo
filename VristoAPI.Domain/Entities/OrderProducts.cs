using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Domain.Entities
{
    public class OrderProducts
    {
        public int OrderID {  get; set; }

        public int ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }
    }
}
