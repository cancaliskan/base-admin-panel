using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using AutoMapper;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Business.Services;
using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.UnitOfWork;
using BaseAdminTemplate.Web.Helpers;
using BaseAdminTemplate.Web.Hubs;

namespace BaseAdminTemplate.Web
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
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddMvcOptions(option => option.Filters.Add(new ActionFilter()));

            services.AddSignalR();

            #region Authentication

            services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.Name = "UserLoginCookie";
                    config.LoginPath = "/Account/Login";
                });

            #endregion

            #region Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IExceptionLogService, ExceptionLogService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IEmailService, EmailService>();
            #endregion

            #region UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region AutoMapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<RoleHub>("/roleHub");
                endpoints.MapHub<UserHub>("/userHub");
            });
        }
    }
}
