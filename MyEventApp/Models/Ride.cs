namespace MyEventApp.Models
{
    public class Ride
    {
        public Guid RideID { get; set; }
        public string RideName { get; set; }
        public int RideType { get; set; }
        public string RideDescription { get; set; }
        public DateTime RideDate { get; set; }
        public decimal RideDistance { get; set; }
    }
}