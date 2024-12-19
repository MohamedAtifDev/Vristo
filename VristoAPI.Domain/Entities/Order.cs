using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VristoAPI.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        
        public string Country {  get; set; }

        public string PhoneNumber { get; set; }


        public DateTime Date {  get; set; }


        [ForeignKey(nameof(PaymentID))]
        public Payments Payment {  get; set; }


        public ICollection<OrderProducts> orderProducts { get; set; }



        public int PaymentID { get; set; }

        public Invoice Invoice { get; set; }
    }
}
