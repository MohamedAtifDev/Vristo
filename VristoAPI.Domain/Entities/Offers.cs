using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Generic;

namespace VristoAPI.Domain.Entities
{
    public class Offers:BaseEntity
    {

        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate{ get; set; }


        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public int ProductID { get; set; }
    }
}
