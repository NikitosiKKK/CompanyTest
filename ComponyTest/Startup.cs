using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponyTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultDatabase");
            services.AddTransient<ICompanyRepository, CompanyRepository>(x => new CompanyRepository(connectionString));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>(x => new EmployeeRepository(connectionString));
            services.AddTransient<IUserRepository, UserRepository>(x => new UserRepository(connectionString));
            services.AddTransient<IDBCreation, DBCreation>(x => new DBCreation(connectionString));
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDBCreationService, DBCreationService>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => //CookieAuthenticationOptions
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login"); 
        });
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация
            app.UseMvcWithDefaultRoute();
            

        }
    }
}
