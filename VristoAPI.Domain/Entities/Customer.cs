using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Domain.Entities
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public Cart Cart { get; set; }  
    }
}
