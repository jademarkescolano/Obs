using DeypalanBooking.Models;
using DeypalanBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeypalanBooking.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesOfferedController : Controller
    {
        ServicesOffered xservices;

        public ServicesOfferedController(ServicesOffered xservices)
        {
            this.xservices = xservices;

        }

        //View Client
        [HttpGet]
        //[Authorize]
        public async Task<List<services>> Services()
        {
            var ret = await xservices.Services();
            return ret;
        }

        //Search Services
        [HttpGet]
        //[Authorize]
        public async Task<List<services>> SearchServices(string search)
        {
            var ret = await xservices.SearchServices(search);
            return ret;
        }


        //Add Services
        [HttpPost]
        //[Authorize]
        public async Task<int> AddServices([FromBody] services _services)
        {
            var ret = await xservices.AddServices(_services);
            return ret;
        }

        //Update Services
        [HttpPost]
        //[Authorize]
        public async Task<int> UpdateServices([FromBody] services _services)
        {
            var ret = await xservices.UpdateServices(_services);
            return ret;
        }

        //Delete Services
        [HttpPost]
        //[Authorize]
        public async Task<int> DeleteServices([FromBody] services _services)
        {
            var ret = await xservices.DeleteServices(_services);
            return ret;
        }


    }
}
