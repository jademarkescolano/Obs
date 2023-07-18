using Microsoft.AspNetCore.SignalR;

namespace DeypalanBooking.Hubs
{
    public class SignalR :Hub
    {
        public async Task SendClient()
        {
            await Clients.All.SendAsync("client");
        }
    }
}
