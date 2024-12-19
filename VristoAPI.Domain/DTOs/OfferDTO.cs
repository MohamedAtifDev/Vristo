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
    public class OfferDTO
    {

        public int Id { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


        [ForeignKey("ProductID")]
        public ProductDTO Product { get; set; }

        public int ProductID { get; set; }
    }
}
