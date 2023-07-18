namespace DeypalanBookingClient.Models
{
    public class availdate
    {
        public int id { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public string? status { get; set; } = "AVAILABLE";
    }
}
