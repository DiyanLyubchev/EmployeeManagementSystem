using EmployeeManagementSystem.Middlewares;
using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemData.Models.Employees;
using EmployeeManagementSystemDataService.Companies;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Employees;
using EmployeeManagementSystemDataService.Search;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ResolveServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ISearchService, SearchService>();

            return services;
        }

        public static IServiceCollection IdentityOptions(this IServiceCollection services)
        {

            services.AddIdentity<User, UserRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<EmployeeManagementSystemContext>()
                 .AddDefaultUI()
                 .AddDefaultTokenProviders();

            return services;

        }


        public static IServiceCollection AddDataBase<TDbContext>(
            this IServiceCollection services, IConfiguration configuration)
            where TDbContext : DbContext
            => services
            .AddDbContext<TDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static IApplicationBuilder UseWebService(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<NotFoundPageMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            return app;
        }

    }
}
