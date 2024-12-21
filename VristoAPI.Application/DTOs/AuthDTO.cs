using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Application.DTOs
{
    public class AuthDTO
    {
        public string Email {  get; set; }

        public string Token { get; set; }

        public DateTime ExpiresAt {  get; set; }


    }
}
