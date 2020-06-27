using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystem.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBase<EmployeeManagementSystemContext>(this.Configuration);
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.IdentityOptions();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc();

            services.ResolveServices();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app.UseWebService(env);
    }
}
