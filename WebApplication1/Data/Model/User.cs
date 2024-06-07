using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data.Model
{
    public class User:IdentityUser
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Booking> BookedDates { get; set; }
    }
}
