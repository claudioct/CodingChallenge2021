using CodingChallenge.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CodingChallenge.Hubs;
using Tossit.RabbitMQ;
using Tossit.WorkQueue;

namespace CodingChallenge
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
            services.AddDbContext<CodingChallengeContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CodingChallengeContext")));
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });

            // Add RabbitMQ implementation dependencies.
            services.AddRabbitMQ();

            // Add Tossit Worker dependencies.
            services.AddTossitWorker();

            // Add Tossit Job dependencies with options.
            services.AddTossitJob(sendOptions =>
            {
                sendOptions.WaitToRetrySeconds = 30;
                sendOptions.ConfirmReceiptIsActive = true;
                sendOptions.ConfirmReceiptTimeoutSeconds = 10;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<LikePostHub>("/likeposthub");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Use RabbitMQ server.
            app.UseRabbitMQServer("amqp://guest:guest@localhost");

            // If this application has worker(s), register it.
            app.UseTossitWorker();
        }
    }
}
