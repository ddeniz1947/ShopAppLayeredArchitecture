using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EFCore;
using ShopApp.DataAccess.Concrete.Memory;
using ShopAppUI.Middlewares;

namespace ShopApp.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        /// <summary>
        /// Burda yaptığımız işlem ; 
        /// UI katmanı => Business Katmanı => Data Access Katmanı arasındaki erişimi sağlamak 
        /// IProductService => ProductManager erişecek //Business Katmanı 
        /// Ardından Business tarafından çağrılacak olan Data Access erişimi ise ;
        /// IProductDal => MemoryProductDal şeklinde olacak.
        /// Burda herhangi bir DB Yaklaşımı bağımlılığımız olmadığını görebiliriz.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductDal, EFCoreProductDal>();
            services.AddScoped<IProductService, ProductManager>();
            services
          // more specific than AddMvc()
          .AddControllersWithViews()
          .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //SADECE GELİŞTİRME AŞAMASINDA ÇALIŞACAK BİR METHOD
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            app.UseStaticFiles(); //wwwroot u dışarıya açmak için 
            app.CustomStaticFiles(); //node_modules 'ü dışarıya açmak için
            app.UseRouting();

            // The equivalent of 'app.UseMvcWithDefaultRoute()'
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                // Which is the same as the template
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
