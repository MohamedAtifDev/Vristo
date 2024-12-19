using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public DateTime LastOpened { get; set; }

        public int CustomerID { get; set; }


        [ForeignKey(nameof(CustomerID))]
        public Customer Customer { get; set; }

    
        public ICollection<CartProducts> cartProducts { get; set; }

    }
}
