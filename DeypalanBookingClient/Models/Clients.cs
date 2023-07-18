namespace DeypalanBookingClient.Models
{
    public class clients
    {
        public int client_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public string gender { get; set; }

        public string contact { get; set; }
        public int serviceid { get; set; }
        public string service { get; set; }
        public DateTime sched { get; set; } = DateTime.Now;
        public string? status { get; set; }
        public string? captcha { get; set; }
    }
}
