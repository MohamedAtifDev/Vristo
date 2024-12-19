using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Domain.Generic
{
    public class BaseEntity
    {

        public DateTime CreatedAt { get; set; }

     
        public Guid CreatedBy { get; set; }


        public DateTime UpdatedAt { get; set; }


        public Guid UpdatedBy { get; set; }


        public DateTime DeletedAt { get; set; }


        public Guid DeletedBy { get; set; }

    }
}
