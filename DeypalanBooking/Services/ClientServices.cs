using DeypalanBooking.Class;
using DeypalanBooking.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace DeypalanBooking.service
{
    public class Clientservices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;



        public Clientservices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        //View Clients
        public async Task<List<clients>> Clients()
        {

            List<clients> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("ViewClients", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new clients
                    {
                        client_id = Convert.ToInt32(rdr["client_id"].ToString()),
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        gender = rdr["gender"].ToString(),
                        contact = rdr["contact"].ToString(),
                        serviceid = Convert.ToInt32(rdr["serviceid"].ToString()),
                        service = rdr["service"].ToString(),
                        sched = Convert.ToDateTime(rdr["sched"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xclient;
        }


        //Client Report
        public async Task<List<clients>> SearchDateClients(DateTime start, DateTime end)
        {
            List<clients> xclient = new();
            try
            {
                using (var con = new MySqlConnection(_constring.GetConnection()))
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchDateClient", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("start_date", start);
                    com.Parameters.AddWithValue("end_date", end);

                    using (var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await rdr.ReadAsync().ConfigureAwait(false))
                        {
                            xclient.Add(new clients
                            {
                                client_id = Convert.ToInt32(rdr["client_id"].ToString()),
                                name = rdr["name"].ToString(),
                                address = rdr["address"].ToString(),
                                gender = rdr["gender"].ToString(),
                                contact = rdr["contact"].ToString(),
                                serviceid = Convert.ToInt32(rdr["serviceid"].ToString()),
                                service = rdr["service"].ToString(),
                                sched = Convert.ToDateTime(rdr["sched"]),
                                status = rdr["status"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
            }
            return xclient;
        }



        //View Clients New
        public async Task<List<clients>> NewClients()
        {

            List<clients> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("ClientNew", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new clients
                    {
                        client_id = Convert.ToInt32(rdr["client_id"].ToString()),
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        //age = rdr["age"].ToString(),
                        gender = rdr["gender"].ToString(),
                        //occupation = rdr["occupation"].ToString(),
                        contact = rdr["contact"].ToString(),
                        service = rdr["service"].ToString(),
                        sched = Convert.ToDateTime(rdr["sched"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xclient;
        }


        //View Clients Approved
        public async Task<List<clients>> ApprovedClients()
        {

            List<clients> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("ClientApproved", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new clients
                    {
                        client_id = Convert.ToInt32(rdr["client_id"].ToString()),
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        //age = rdr["age"].ToString(),
                        gender = rdr["gender"].ToString(),
                        //occupation = rdr["occupation"].ToString(),
                        contact = rdr["contact"].ToString(),
                        service = rdr["service"].ToString(),
                        sched = Convert.ToDateTime(rdr["sched"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xclient;
        }


        //View Clients Released
        public async Task<List<clients>> ReleasedClients()
        {

            List<clients> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("ClientReleased", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new clients
                    {
                        client_id = Convert.ToInt32(rdr["client_id"].ToString()),
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        //age = rdr["age"].ToString(),
                        gender = rdr["gender"].ToString(),
                        //occupation = rdr["occupation"].ToString(),
                        contact = rdr["contact"].ToString(),
                        service = rdr["service"].ToString(),
                        sched = Convert.ToDateTime(rdr["sched"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xclient;
        }

        //View Clients Declined
        public async Task<List<clients>> DeclinedClients()
        {

            List<clients> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("ClientDeclined", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new clients
                    {
                        client_id = Convert.ToInt32(rdr["client_id"].ToString()),
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        //age = rdr["age"].ToString(),
                        gender = rdr["gender"].ToString(),
                        //occupation = rdr["occupation"].ToString(),
                        contact = rdr["contact"].ToString(),
                        service = rdr["service"].ToString(),
                        sched = Convert.ToDateTime(rdr["sched"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xclient;
        }

        //Search Clients
        public async Task<List<clients>> SearchClient(string search)
        {
            List<clients> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SearchClient", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@search", search);
                com.Parameters.AddWithValue("@searchWildcard", $"%{search}%");

                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new clients
                    {
                        client_id = Convert.ToInt32(rdr["client_id"]),
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        //age = rdr["age"].ToString(),
                        gender = rdr["gender"].ToString(),
                        //occupation = rdr["occupation"].ToString(),
                        contact = rdr["contact"].ToString(),
                        service = rdr["service"].ToString(),
                        sched = Convert.ToDateTime(rdr["sched"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xclient;
        }




        //Insert Clients
        public async Task<int> AddClient(clients xclient)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("INSERT INTO clients (client_id,name,address,gender,contact,serviceid,sched,status) VALUES (@client_id,@name,@address,@gender,@contact,@serviceid,@sched,@status)", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@client_id", xclient.client_id);
                com.Parameters.AddWithValue("@name", xclient.name);
                com.Parameters.AddWithValue("@address", xclient.address);
                com.Parameters.AddWithValue("@gender", xclient.gender);
                com.Parameters.AddWithValue("@contact", xclient.contact);
                com.Parameters.AddWithValue("@serviceid", xclient.serviceid);
                //com.Parameters.AddWithValue("@service", xclient.service);
                com.Parameters.AddWithValue("@sched", xclient.sched);
                com.Parameters.AddWithValue("@status", xclient.status);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);

            }

            return i;
        }

        public async Task<int> UpdateClient(clients xclient)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UPDATE clients SET name=@name, address=@address, gender=@gender, contact=@contact, serviceid=@serviceid,sched=@sched, status=@status WHERE client_id=@client_id", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@client_id", xclient.client_id);
                com.Parameters.AddWithValue("@name", xclient.name);
                com.Parameters.AddWithValue("@address", xclient.address);
                com.Parameters.AddWithValue("@gender", xclient.gender);
                com.Parameters.AddWithValue("@contact", xclient.contact);
                com.Parameters.AddWithValue("@serviceid", xclient.serviceid);
                /*com.Parameters.AddWithValue("@service", xclient.service);*/
                com.Parameters.AddWithValue("@sched", xclient.sched);
                com.Parameters.AddWithValue("@status", xclient.status);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }


        public async Task<int> Approved(clients xclient)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UPDATE clients SET status = 'APPROVED' WHERE client_id = @client_id", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@client_id", xclient.client_id);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }

        public async Task<int> Declined(clients xclient)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UPDATE clients SET status = 'DECLINED' WHERE client_id = @client_id", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@client_id", xclient.client_id);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }

        public async Task<int> Released(clients xclient)
        {
            int i = 0;
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UPDATE clients SET status = 'RELEASED' WHERE client_id = @client_id", con)
                {
                    CommandType = CommandType.Text,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@client_id", xclient.client_id);
                i = await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }

            return i;
        }


        //View Clients
        public async Task<List<clients>> SchedToday()
        {

            List<clients> xclient = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("ClientToday", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    xclient.Add(new clients
                    {
                        client_id = Convert.ToInt32(rdr["client_id"].ToString()),
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        //age = rdr["age"].ToString(),
                        gender = rdr["gender"].ToString(),
                        //occupation = rdr["occupation"].ToString(),
                        contact = rdr["contact"].ToString(),
                        service = rdr["service"].ToString(),
                        sched = Convert.ToDateTime(rdr["sched"]),
                        status = rdr["status"].ToString(),
                    });
                }
            }
            return xclient;
        }

        //Count New
        public async Task<int> New()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE status = 'NEW'", con)
                {
                    CommandType = CommandType.Text,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        //Count Approved
        public async Task<int> Approved()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE status = 'APPROVED'", con)
                {
                    CommandType = CommandType.Text,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        //Count Released
        public async Task<int> Released()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE status = 'RELEASED'", con)
                {
                    CommandType = CommandType.Text,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        //Count Declined
        public async Task<int> Declined()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE status = 'DECLINED'", con)
                {
                    CommandType = CommandType.Text,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

    }
}
