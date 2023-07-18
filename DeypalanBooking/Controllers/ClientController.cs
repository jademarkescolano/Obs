using DeypalanBooking.Class;
using DeypalanBooking.Hubs;
using DeypalanBooking.Models;
using DeypalanBooking.service;
using DeypalanBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Reporting.NETCore;
using System.Data;

namespace DeypalanBooking.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        Clientservices xservices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        //SignalR
        IHubContext<SignalR> _hub;
        public ClientController(Clientservices xservices, IHubContext<SignalR> hubContext, IWebHostEnvironment webHostEnvironment)
        {
            this.xservices = xservices;
            _hub = hubContext;
            _webHostEnvironment = webHostEnvironment;
        }

        //View Client
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> Clients()
        {
            var ret = await xservices.Clients();
            return ret;
        }


        //Client Report By Date
        [HttpGet]
        public async Task<IActionResult> ClientReport(DateTime start, DateTime end)
        {
            ListtoTable listtoTable = new();
            var dt = new DataTable();
            var lst = await xservices.SearchDateClients(start, end);
            dt = listtoTable.ToDataTablee(lst);
            string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "ClientReport.rdlc");
            Stream reportDefinition;

            using var fs = new FileStream(reportPath, FileMode.Open);
            reportDefinition = fs;
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(reportDefinition);
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            byte[] excel = report.Render("EXCEL");
            fs.Dispose();

            return File(excel, "application/msexcel", "ClientReport.xls");
        }


        //Search Date  Clients
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> SearchDateClients(DateTime start, DateTime end)
        {
            var ret = await xservices.SearchDateClients(start, end);
            return ret;
        }


        //View Client New
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> NewClients()
        {
            var ret = await xservices.NewClients();
            return ret;
        }

        //View Client Approved
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> ApprovedClients()
        {
            var ret = await xservices.ApprovedClients();
            return ret;
        }

        //View Client Released
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> ReleasedClients()
        {
            var ret = await xservices.ReleasedClients();
            return ret;
        }

        //View Client Declined
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> DeclinedClients()
        {
            var ret = await xservices.DeclinedClients();
            return ret;
        }

        //Add Client
        [HttpPost]
        //[Authorize]
        public async Task<int> AddClient([FromBody] clients xclient)
        {
            var ret = await xservices.AddClient(xclient);
            return ret;
        }

        //Update Client
        [HttpPost]
        //[Authorize]
        public async Task<int> UpdateClient([FromBody] clients xclient)
        {
            var ret = await xservices.UpdateClient(xclient);
            return ret;
        }

        //Update Client
        [HttpPost]
        //[Authorize]
        public async Task<int> Approved([FromBody] clients xclient)
        {
            var ret = await xservices.Approved(xclient);
            return ret;
        }


        [HttpPost]
        public async Task<int> Declined([FromBody] clients xclient)
        {
            var ret = await xservices.Declined(xclient);
            return ret;
        }


        [HttpPost]
        public async Task<int> Released([FromBody] clients xclient)
        {
            var ret = await xservices.Released(xclient);
            return ret;
        }



        //Search Clients
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> SearchClient(string search)
        {
            var ret = await xservices.SearchClient(search);
            return ret;
        }



        //Sched Today
        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> SchedToday()
        {
            var ret = await xservices.SchedToday();
            return ret;
        }

        //Count New
        [HttpGet]
        //[Authorize]
        public async Task<int> New()
        {
            return await xservices.New();
        }

        //Count Approved
        [HttpGet]
        //[Authorize]
        public async Task<int> Approved()
        {
            return await xservices.Approved();
        }

        //Count Released
        [HttpGet]
        //[Authorize]
        public async Task<int> Released()
        {
            return await xservices.Released();
        }

        //Count Declined
        [HttpGet]
        //[Authorize]
        public async Task<int> Declined()
        {
            return await xservices.Declined();
        }

    }
}
