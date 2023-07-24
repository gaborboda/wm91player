using Microsoft.AspNetCore.Identity;
using Sm91.Play.Entities;

namespace Sm91.Play.Domain
{
    public class User : IdentityUser
    {
        public DateTime DateCreated { get; set; }
        public string? Twitter { get; set; }
        public string? Scatbook { get; set; }
        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
