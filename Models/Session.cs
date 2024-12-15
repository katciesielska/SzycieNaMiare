using Microsoft.AspNetCore.Identity;

namespace SzycieNaMiare.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
