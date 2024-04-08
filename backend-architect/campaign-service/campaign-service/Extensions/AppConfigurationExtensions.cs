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
    public static class AppConfigurationExtensions
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            var jwtSecret = config["Jwt:Secret"];
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString), optionsLifetime: ServiceLifetime.Singleton);

            builder.Services.AddDbContextFactory<ApplicationDbContext>();
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddTransient<ICampaignService, CampaignService>();

            builder.Services.AddControllers();

            var key = Encoding.ASCII.GetBytes(jwtSecret);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });

            return builder;
        }
    }
}