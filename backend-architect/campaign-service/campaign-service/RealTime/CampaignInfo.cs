using Microsoft.AspNetCore.SignalR;

namespace campaign_service.RealTime
{
    public sealed class CampaignHub : Hub<ICampaignClient>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.CampaignMessage($"{Context.ConnectionId} is connected");
        }

        public async Task SendCampaign(String message)
        {
            await Clients.All.CampaignMessage($"{Context.ConnectionId} {message}");
        }
    }
}