using System.ComponentModel.DataAnnotations.Schema;

namespace MyEventApp.Models
{
    public class Entry
    {
        public Guid EntryId { get; set; }
        public string EventID { get; set; }
        public Guid MemberID { get; set; }
        public DateTime? EventTime { get; set; }

        [ForeignKey("MemberID")]
        public Member Member { get; set; }
    }
}