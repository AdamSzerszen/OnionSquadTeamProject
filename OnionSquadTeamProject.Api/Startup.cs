using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Repositories.Users;
using OnionSquadTeamProject.Api.Repositories.Watchers;
using OnionSquadTeamProject.Api.Services.Mailing;
using OnionSquadTeamProject.Api.Services.Sending;
using AuthenticationService = OnionSquadTeamProject.Api.Services.Authentication.AuthenticationService;
using IAuthenticationService = OnionSquadTeamProject.Api.Services.Authentication.IAuthenticationService;

namespace OnionSquadTeamProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
                .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<ISendingService, FakeSendingService>();
            services.AddScoped<IWatchersRepository, FakeWatchersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
