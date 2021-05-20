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

            services.AddIdentity<ApplicationUser, IdentityRole>() //identity ye uygulamayý tanýttýk
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>() //datalarý nerede saklayacak
                .AddDefaultTokenProviders() //benzersiz bir deðer göndermesi için
                .AddDefaultUI();

            services.Configure<IdentityOptions>(options =>
            {
                // password

                options.Password.RequireDigit = true; //sayýsal deðer olmalý
                options.Password.RequireLowercase = true; //küçük bir karakter
                options.Password.RequiredLength = 6; //m,n,mum kaç karakter
                options.Password.RequireNonAlphanumeric = true; //alfanumeric olsun mu
                options.Password.RequireUppercase = true; //büyük harf olsun

                options.Lockout.MaxFailedAccessAttempts = 5; //kaç kere þifreyi yanlýþ girme hakký olsun
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //haklarý dolduktan sonra kullanýcýnýn login olmasý için geçmesi gereken süre
                options.Lockout.AllowedForNewUsers = true; //lockout iþlemi yeni kullanýcý için geçerli

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true; //mail adresi önceden kullanýlmýþsa ona yeni üyelik oluþturmaz

                options.SignIn.RequireConfirmedEmail = true; //login olmak için mail onayý hesap açýmýnda
                options.SignIn.RequireConfirmedPhoneNumber = false; //telefon onayý istenirse true yapýlacak
            });
            
            //cookie ayarlarý
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied"; //yetkisi olmayan alanlarda
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //cookie ye bir süre verdik(ne kadar süre tarayýcýda saklanacak)
                options.SlidingExpiration = true; //false olursa uygulamay tekrar baðlansýn ya da baðlanmasýn cookie nin süresi biter
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, //scriptler cookie lere ulaþamaz
                    Name = ".ShopApp.Security.Cookie", //varsayýlan isim kullanmak yerine isim verdik
                    SameSite = SameSiteMode.Strict
                };

            });

            //Altyapýdaki teknolojiyi deðiþtirirsem sadece MemoryProductDal ý deðiþtiricem
            services.AddScoped<IProductDal, EfCoreProductDal>();//IProductDal istenirse MemoryProductDal gönder
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();

            //Baþka bir iþ katmanýnda çalýþmak istersem ya da verisonu deðiþtirirsem sadece ProductManager ý deðiþtiricem
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
