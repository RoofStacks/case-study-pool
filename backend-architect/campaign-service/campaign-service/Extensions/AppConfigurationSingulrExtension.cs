using System.Text;
using campaign_service.Repositories;
using campaign_service.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using campaign_service.Services.Campaigns;

namespace campaign_service.Extensions
{
    /// <summary>
    /// Configuration for real time base application
    /// </summary>
    public static class AppConfigurationSingulrExtension
    {
        public static WebApplicationBuilder ConfigureRealTimeBase(this WebApplicationBuilder builder)
        {
            builder.Services.AddSignalR();

            return builder;
        }
    }
}