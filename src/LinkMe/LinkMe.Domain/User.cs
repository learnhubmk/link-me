using Microsoft.AspNetCore.Identity;

namespace LinkMe.Domain
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public ICollection<Review> ReviewsLeft { get; set; }
    }
}
