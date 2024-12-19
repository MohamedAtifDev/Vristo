using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.DTOs
{
    public class PaymentsDTO
    {
        [Key]

        public int Id { get; set; }


        public DateTime DateTime { get; set; }

        public string ResponseJson { get; set; }


        public string Status { get; set; }

        public OrderDTO Order { get; set; }
    }
}
