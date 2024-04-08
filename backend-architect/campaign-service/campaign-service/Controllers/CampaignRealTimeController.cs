using System;
using campaign_service.dto;
using campaign_service.Models;
using campaign_service.RealTime;
using campaign_service.Services.Campaigns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace campaign_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignRealTimeController : ControllerBase
    {
        private readonly IHubContext<CampaignHub, ICampaignClient> hubContext;

        public CampaignRealTimeController(IHubContext<CampaignHub, ICampaignClient> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpPost("broadcast")]
        public async Task<ActionResult> broadcast(string message)
        {
            await this.hubContext.Clients.All.CampaignMessage(message);
            return Ok();
        }
    }
}