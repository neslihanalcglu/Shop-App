using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Middlewares;

namespace ShopApp.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>() //identity ye uygulamay� tan�tt�k
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>() //datalar� nerede saklayacak
                .AddDefaultTokenProviders() //benzersiz bir de�er g�ndermesi i�in
                .AddDefaultUI();

            services.Configure<IdentityOptions>(options =>
            {
                // password

                options.Password.RequireDigit = true; //say�sal de�er olmal�
                options.Password.RequireLowercase = true; //k���k bir karakter
                options.Password.RequiredLength = 6; //m,n,mum ka� karakter
                options.Password.RequireNonAlphanumeric = true; //alfanumeric olsun mu
                options.Password.RequireUppercase = true; //b�y�k harf olsun

                options.Lockout.MaxFailedAccessAttempts = 5; //ka� kere �ifreyi yanl�� girme hakk� olsun
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //haklar� dolduktan sonra kullan�c�n�n login olmas� i�in ge�mesi gereken s�re
                options.Lockout.AllowedForNewUsers = true; //lockout i�lemi yeni kullan�c� i�in ge�erli

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true; //mail adresi �nceden kullan�lm��sa ona yeni �yelik olu�turmaz

                options.SignIn.RequireConfirmedEmail = true; //login olmak i�in mail onay� hesap a��m�nda
                options.SignIn.RequireConfirmedPhoneNumber = false; //telefon onay� istenirse true yap�lacak
            });
            
            //cookie ayarlar�
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied"; //yetkisi olmayan alanlarda
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //cookie ye bir s�re verdik(ne kadar s�re taray�c�da saklanacak)
                options.SlidingExpiration = true; //false olursa uygulamay tekrar ba�lans�n ya da ba�lanmas�n cookie nin s�resi biter
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, //scriptler cookie lere ula�amaz
                    Name = ".ShopApp.Security.Cookie", //varsay�lan isim kullanmak yerine isim verdik
                    SameSite = SameSiteMode.Strict
                };

            });

            //Altyap�daki teknolojiyi de�i�tirirsem sadece MemoryProductDal � de�i�tiricem
            services.AddScoped<IProductDal, EfCoreProductDal>();//IProductDal istenirse MemoryProductDal g�nder
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();

            //Ba�ka bir i� katman�nda �al��mak istersem ya da verisonu de�i�tirirsem sadece ProductManager � de�i�tiricem
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            //IProduct,EfCoreProductDal
            //IProduct, MySqlProductDal

            

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "adminProducts",
                 template: "admin/products",
                 defaults: new { controller = "Admin", action = "ProductList" }
               );

                routes.MapRoute(
                    name: "adminProducts1",
                    template: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "EditProduct" }
                );

                routes.MapRoute(
                  name: "products",
                  template: "products/{category?}",
                  defaults: new { controller = "Shop", action = "List" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );

            });

        }
    }
}
