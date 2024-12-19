using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.DTOs
{
    public class CartDTO
    {
        [Key]
        public int Id { get; set; }

        public DateTime LastOpened { get; set; }

        public int CustomerID { get; set; }


        public CustomerDTO Customer { get; set; }


        public ICollection<CartProductsDTO> cartProducts { get; set; }
    }
}
