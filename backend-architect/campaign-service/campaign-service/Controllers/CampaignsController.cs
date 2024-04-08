using System;
using campaign_service.dto;
using campaign_service.Models;
using campaign_service.Services.Campaigns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace campaign_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCampaignResponse>>> GetCampaigns([FromQuery] GetCampaignRequest getCampaignRequest)
        {
            return Ok(_campaignService.Get(getCampaignRequest).Result);
        }

        [HttpPost] 
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult<GetCampaignResponse>> Save([FromBody] GetCampaignRequest getCampaignRequest)
        {
            var response =_campaignService.Save(getCampaignRequest);
            return Ok(response.Result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(_campaignService.Delete(id).Result);
        }
    }
}