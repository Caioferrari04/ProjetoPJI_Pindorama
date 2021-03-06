using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pindorama.Auth;
using Pindorama.Data;
using Pindorama.Hubs;
using Pindorama.Models;
using Pindorama.Services;
using Pindorama.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Pindorama
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

            services.AddDbContext<PindoramaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Pindorama_db")));

            services.AddDefaultIdentity<Usuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PindoramaContext>()
                .AddErrorDescriber<ErrorDescriber>();

            services.AddScoped<AuthService>();
            services.AddScoped<GamesService>();
            services.AddTransient<CategoriasService>();

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Loja}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            if (HybridSupport.IsElectronActive)
            {
                ElectronStatup();
            }
            CreateRoles(serviceProvider);
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = Enum.GetNames(typeof(RoleTypes)); ;
            foreach (var role in roleNames)
            {
                var roleExist = roleManager.RoleExistsAsync(role);
                if (!roleExist.Result)
                {
                    var roleResult = roleManager.CreateAsync(new IdentityRole(role));
                    roleResult.Wait();
                }
            }
        }

        private async void ElectronStatup()
        {
            CreateMenu();
            var window = await Electron.WindowManager.CreateWindowAsync(
                new BrowserWindowOptions
                {
                    Width = 1152,
                    Height = 940,
                    Show = false
                } 
            );

            await window.WebContents.Session.ClearCacheAsync();

            window.OnReadyToShow += () => window.Show();
            window.SetTitle("Pindorama");

            window.OnClosed += () => {
                Electron.App.Quit();
            };
        }
        private void CreateMenu()
        {
            bool isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            MenuItem[] menu = null;

            MenuItem[] appMenu = new MenuItem[]
            {
                new MenuItem { Role = MenuRole.about },
                new MenuItem { Type = MenuType.separator },
                new MenuItem { Role = MenuRole.services },
                new MenuItem { Type = MenuType.separator },
                new MenuItem { Role = MenuRole.quit }
            };

            MenuItem[] fileMenu = new MenuItem[]
            {
                new MenuItem { Role = isMac ? MenuRole.close : MenuRole.quit }
            };

            MenuItem[] viewMenu = new MenuItem[]
            {
                new MenuItem { Role = MenuRole.reload },
                new MenuItem { Role = MenuRole.forcereload },
                new MenuItem { Role = MenuRole.toggledevtools },
                new MenuItem { Type = MenuType.separator },
                new MenuItem { Role = MenuRole.resetzoom },
                new MenuItem { Type = MenuType.separator },
                new MenuItem { Role = MenuRole.togglefullscreen }
            };

            if (isMac)
            {
                menu = new MenuItem[]
                {
            new MenuItem {
                Label = "Electron",
                Type = MenuType.submenu,
                Submenu = appMenu
            },
            new MenuItem {
                Label = "File",
                Type = MenuType.submenu,
                Submenu = fileMenu
            },
            new MenuItem {
                Label = "View",
                Type = MenuType.submenu,
                Submenu = viewMenu
            }
                };
            }
            else
            {
                menu = new MenuItem[]
                {
            new MenuItem {
                Label = "File",
                Type = MenuType.submenu,
                Submenu = fileMenu
            },
            new MenuItem {
                Label = "View",
                Type = MenuType.submenu,
                Submenu = viewMenu
            }
                };
            }

            Electron.Menu.SetApplicationMenu(menu);
        }
    }
}
