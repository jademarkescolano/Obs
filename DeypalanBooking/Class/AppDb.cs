namespace DeypalanBooking.Class
{
    public class AppDb
    {
        public IConfiguration Configuration { get; }
        public string GetConnection() => Configuration.GetSection("ConnectionStrings").GetSection("DBConstring").Value;

        public AppDb(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
