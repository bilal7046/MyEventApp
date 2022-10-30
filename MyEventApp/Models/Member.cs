using Microsoft.AspNetCore.Identity;

namespace MyEventApp.Models
{
    public class Member
    {
        public Guid MemberID { get; set; }
        public string RaceTechID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MemberType { get; set; }
        public DateTime JoinDate { get; set; }
        public bool PaidUp { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}