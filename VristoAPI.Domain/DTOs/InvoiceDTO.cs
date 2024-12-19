using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Domain.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }

        public IFormFile InvoiceFile { get; set; }

        public OrderDTO? Order { get; set; }

 
        public int OrderID { get; set; }
    }
}
