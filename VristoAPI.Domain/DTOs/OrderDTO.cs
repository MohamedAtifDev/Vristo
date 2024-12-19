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
    public  class OrderDTO
    {
  
        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }


        public string Country { get; set; }

        public string PhoneNumber { get; set; }


        public DateTime Date { get; set; }


     
        public PaymentsDTO Payment { get; set; }


        public ICollection<OrderProducts> orderProducts { get; set; }



        public int PaymentID { get; set; }

        public InvoiceDTO Invoice { get; set; }
    }
}
