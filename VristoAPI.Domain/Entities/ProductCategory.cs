using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Generic;

namespace VristoAPI.Domain.Entities
{
    public class ProductCategory:BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }=string.Empty;

        [StringLength(200)]
        public string? Description { get; set; }=string.Empty;

        public ICollection<Product> Products { get; set; }
    }
}
