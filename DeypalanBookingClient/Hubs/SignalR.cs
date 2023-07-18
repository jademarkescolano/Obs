using Microsoft.AspNetCore.SignalR;

namespace DeypalanBookingClient.Hubs
{
    public class SignalR :Hub
    {
        public async Task SendClient()
        {
            await Clients.All.SendAsync("client");
        }
    }
}
