using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Application.Models
{
    public  class Register
    {

        [Required(ErrorMessage ="Email Is Required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email")]
        public string Email {  get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password Is Required")]
        public string Password {  get; set; }

    }
}
