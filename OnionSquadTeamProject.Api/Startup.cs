using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnionSquadTeamProject.Api.Authentication;
using OnionSquadTeamProject.Api.Repositories.Users;
using OnionSquadTeamProject.Api.Repositories.Watchers;
using OnionSquadTeamProject.Api.Services.Authentication;
using OnionSquadTeamProject.Api.Services.Mailing;
using OnionSquadTeamProject.Api.Services.Sending;

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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<ISendingService, FakeSendingService>();
            services.AddSingleton<IWatchersRepository, FakeWatchersRepository>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IUserService, UserService>();
            
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

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "mailing",
                    pattern: "mailing/{action}/{*param}",
                    defaults: new { controller = "mailing", action = "send" });
                endpoints.MapControllers();
            });
        }
    }
}
