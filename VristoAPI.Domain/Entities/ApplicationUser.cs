
using Microsoft.AspNetCore.Identity;

namespace VristoAPI.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {

        public Cart cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
