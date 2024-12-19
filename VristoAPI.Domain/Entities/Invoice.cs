using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Domain.Entities
{
    public  class Invoice
    {
        public int Id { get; set; }

        public byte[] InvoiceFile {  get; set; }

        public Order Order { get; set; }

        [ForeignKey(nameof(OrderID))]
        public int OrderID {  get; set; }
    }
}
