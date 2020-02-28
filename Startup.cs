using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using EDTProjectM1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EDTProjectM1
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(config =>
            {
                config.AddPolicy("RequireGestionnaireRole",
                    policy => policy.RequireRole("Gestionnaire"));
            });

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });

            CreateRolesAsync(serviceProvider).Wait();
            CreateSuperUser(userManager).Wait();
        }

        private async Task CreateSuperUser(UserManager<IdentityUser> userManager)
        {
            if(await userManager.FindByNameAsync("gestionnaire@edtproject.fr") == null)
            {
                var gestionnaire = new IdentityUser { UserName = "gestionnaire@edtproject.fr", Email = "gestionnaire@edtproject.fr" };
                await userManager.CreateAsync(gestionnaire, "Gestionnaire1234!");
            
                var token = await userManager.GenerateEmailConfirmationTokenAsync(gestionnaire);
                await userManager.ConfirmEmailAsync(gestionnaire, token);
                await userManager.AddToRoleAsync(gestionnaire, "Gestionnaire");
            }
        }

        private async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string roleName = "Gestionnaire";
            IdentityResult roleResult;

            //creating the roles and seeding them to the database
            var roleExist = await RoleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

    }
}
