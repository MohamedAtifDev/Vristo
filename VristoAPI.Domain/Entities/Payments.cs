using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.Entities
{
    public class Payments
    {
        [Key]

        public int Id { get; set; }


        public DateTime DateTime { get; set; }

        public string ResponseJson {  get; set; }


        public string Status {  get; set; }

        public Order Order { get; set; }
    }
}
