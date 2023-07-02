using DALSevenCodeOnlineStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BLLSevenCodeOnlineStore.BaseRepository;
using BLLSevenCodeOnlineStore.ModelRepositories.Admin;

namespace GUISevenCodeOnlineStore
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
          //  services.AddControllersWithViews();

            //add identity
            services.AddIdentity<ApplicationUser, IdentityRole>()    // Seethis: for forx design password : not used untilnow :https://stackoverflow.com/a/46229180
                .AddEntityFrameworkStores<SevenCodeOnlineStoreContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                //options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<SevenCodeOnlineStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SevenCodeOnlineStoreConnectionString")));

            services.AddControllersWithViews();
            services.AddRazorPages();

            #region Repositories

            //services.AddScoped(typeof(IBaseRepository<Page>), typeof(BaseRepository<Page>));

            services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
            services.AddScoped<IProductRepository, ProductRepository>();
           

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

            app.UseCookiePolicy();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                //http://localhost:63671/Admin/home/Index   // http://localhost:63671/Admin/admin/about   // 
                //Note: Area routing must be placed first with non area routing, area: exists is compulsory to add area routing.
                endpoints.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=HomeEnglish}/{action=Index}/{id?}");

                //to work with Customer //
                endpoints.MapAreaControllerRoute(
               name: "Customer",
               areaName: "Customer",
               pattern: "Customer/{controller=Home}/{action=Index}/{id?}");


                //to work with identity //Built in //
                endpoints.MapAreaControllerRoute(
                name: "Identity",
                areaName: "Identity",
                pattern: "Identity/{controller=Home}/{action=Index}/{id?}");



                endpoints.MapControllerRoute(
                    name: "default2",
                    pattern: "{language=ar}/{controller=Home}/{action=Home}/{id?}", //pattern: "{language=ar}/{controller=Home}/{action=Home}/{id?}",
                    defaults: new { language = "ar", controller = "Home", action = "Home" } //,
                    //constraints: new { culture = "en|ar" }
                        );


                //endpoints.MapAreaControllerRoute(
                //name: "Admin",
                //areaName: "Admin",
                //pattern: "Admin/{controller=HomeArabic}/{action=Index}/{id?}");
                //Admin / HomeArabic / mm
                //****************1

                //endpoints.MapControllerRoute(
                //    name: "Root",
                //    //Url: "{culture}/{controller}/{action}/{id}",
                //    pattern: "{language=ar}/{controller=Base}/{action=RedirectToLocalized}" //, //pattern: "{language=ar}/{controller=Home}/{action=Home}/{id?}",
                //                                                                            //defaults: new { language = "ar", controller = "Home", action = "Home" }
                //        );
                //****************************1
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
