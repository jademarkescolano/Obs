using DeypalanBooking.Hubs;
using DeypalanBooking.Models;
using DeypalanBooking.service;
using DeypalanBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DeypalanBooking.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AvailDateController : Controller
    {
        AvailDateServices xservices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        //SignalR
        IHubContext<SignalR> _hub;
        public AvailDateController(AvailDateServices xservices, IHubContext<SignalR> hubContext, IWebHostEnvironment webHostEnvironment)
        {
            this.xservices = xservices;
            _hub = hubContext;
            _webHostEnvironment = webHostEnvironment;
        }

        //View Avail Date
        [HttpGet]
        //[Authorize]
        public async Task<List<availdate>> AvailDate()
        {
            var ret = await xservices.AvailDate();
            return ret;
        }

        //Add Avail Date
        [HttpPost]
        //[Authorize]
        public async Task<int> AddAvailDate([FromBody] availdate xavaildate)
        {
            var ret = await xservices.AddAvailDate(xavaildate);
            return ret;
        }
        //Update Avail Date
        [HttpPost]
        //[Authorize]
        public async Task<int> UpdateAvailDate([FromBody] availdate xavaildate)
        {
            var ret = await xservices.UpdateAvailDate(xavaildate);
            return ret;
        }

        //Delete Avail Date
        [HttpPost]
        //[Authorize]
        public async Task<int> DeleteAvailDate([FromBody] availdate xavaildate)
        {
            var ret = await xservices.DeleteAvailDate(xavaildate);
            return ret;
        }

        //Search Schedule Date
        [HttpGet]
        //[Authorize]
        public async Task<List<availdate>> SearchScheduleDate(DateTime date)
        {
            var ret = await xservices.SearchScheduleDate(date);
            return ret;
        }
    }
}
