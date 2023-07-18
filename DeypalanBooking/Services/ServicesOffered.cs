using DeypalanBooking.Class;
using DeypalanBooking.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace DeypalanBooking.Services
{
    public class ServicesOffered
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;



        public ServicesOffered(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        //View Services
        public async Task<List<services>> Services()
        {

            List<services> xservices = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SELECT * FROM services", con)
                {
                    CommandType = CommandType.Text,
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xservices.Add(new services
                    {
                        serviceid = Convert.ToInt32(rdr["serviceid"].ToString()),
                        service = rdr["service"].ToString(),
                        price = Convert.ToDouble( rdr["price"])
                    });
                }
            }
            return xservices;
        }


        //Search Clients
        public async Task<List<services>> SearchServices(string search)
        {
            List<services> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SELECT * FROM deypalan.services WHERE serviceid = @search OR service LIKE @searchWildcard OR  price LIKE @searchWildcard ", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@search", search);
                com.Parameters.AddWithValue("@searchWildcard", $"%{search}%");

                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new services
                    {
                        serviceid = Convert.ToInt32(rdr["serviceid"].ToString()),
                        service = rdr["service"].ToString(),
                        price = Convert.ToDouble(rdr["price"])
                    });
                }
            }
            return xclient;
        }


        public async Task<int> AddServices(services xservices)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("INSERT INTO services (serviceid,service,price) VALUES (@serviceid,@service,@price)", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@serviceid", xservices.serviceid);
                com.Parameters.AddWithValue("@service", xservices.service);
                com.Parameters.AddWithValue("@price", xservices.price);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);

            }

            return i;
        }

        public async Task<int> UpdateServices(services xservices)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UPDATE services SET service = @service, price = @price WHERE serviceid = @serviceid", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@serviceid", xservices.serviceid);
                com.Parameters.AddWithValue("@service", xservices.service);
                com.Parameters.AddWithValue("@price", xservices.price);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);

            }

            return i;
        }

        public async Task<int> DeleteServices(services xservices)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("DELETE FROM services WHERE serviceid = @serviceid", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@serviceid", xservices.serviceid);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }


    }
}
