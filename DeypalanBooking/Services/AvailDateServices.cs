using DeypalanBooking.Class;
using DeypalanBooking.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace DeypalanBooking.Services
{
    public class AvailDateServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;



        public AvailDateServices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        //View Available Dates
        public async Task<List<availdate>> AvailDate()
        {

            List<availdate> xdate = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SELECT * FROM availdate", con)
                {
                    CommandType = CommandType.Text,
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xdate.Add(new availdate
                    {
                        id = Convert.ToInt32(rdr["id"].ToString()),
                        date = Convert.ToDateTime(rdr["date"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xdate;
        }

        //Insert Clients
        public async Task<int> AddAvailDate(availdate xavaildate)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("INSERT INTO availdate (id,date,status) VALUES (@id,@date,@status)", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@id", xavaildate.id);
                com.Parameters.AddWithValue("@date", xavaildate.date);
                com.Parameters.AddWithValue("@status", xavaildate.status);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }

        public async Task<int> UpdateAvailDate(availdate xavaildate)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UPDATE availdate SET status = @status WHERE id = @id AND date = @date", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@id", xavaildate.id);
                com.Parameters.AddWithValue("@date", xavaildate.date);
                com.Parameters.AddWithValue("@status", xavaildate.status);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }

        //Delete Avail Date
        public async Task<int> DeleteAvailDate(availdate xavaildate)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("DELETE FROM availdate WHERE id = @id", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@id", xavaildate.id);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }



        //SearchDate
        public async Task<List<availdate>> SearchScheduleDate(DateTime date)
        {
            List<availdate> xavaildate = new();
            try
            {
                using (var con = new MySqlConnection(_constring.GetConnection()))
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchScheduleDate", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("sdate", date);
                    using (var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await rdr.ReadAsync().ConfigureAwait(false))
                        {
                            xavaildate.Add(new availdate
                            {
                                id = Convert.ToInt32(rdr["id"].ToString()),
                                date = Convert.ToDateTime(rdr["date"]),
                                status = rdr["status"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
            }
            return xavaildate;
        }

    }
}
