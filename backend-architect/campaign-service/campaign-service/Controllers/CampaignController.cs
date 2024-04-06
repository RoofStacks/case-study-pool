using Microsoft.AspNetCore.Mvc;

namespace campaign_service.Controllers;

[ApiController]
[Route("[controller]")]
public class CampaignController : ControllerBase
{
    
    
    private readonly ILogger<CampaignController> _logger;

    public CampaignController(ILogger<CampaignController> logger)
    {
        _logger = logger;
    }

    public IEnumerable<bool> Get()
    {
                return new List<bool>();
    }
}
