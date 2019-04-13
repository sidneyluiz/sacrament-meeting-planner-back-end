using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlanner.Data.Context;
using System;

namespace SacramentMeetingPlanner
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
            try
            {
                services
                     .AddMvc()
                     .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                services.AddDbContext<SacramentMeetingPlannerContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString(nameof(SacramentMeetingPlannerContext))));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyHeader();
                c.AllowAnyMethod();
            });

            app.UseMvc();
        }
    }
}
