using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreMVC.Models.DISample;
using static NetCoreMVC.Models.DISample.DISample;

namespace NetCoreMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //此方法是用來將服務註冊到 DI 容器用的    
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
          
            services.AddTransient<ISampleTransient, LifeCycleSample>();
            services.AddScoped<ISampleScoped, LifeCycleSample>();
            services.AddSingleton<ISampleSingleton, LifeCycleSample>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 用來指定應用程式對 HTTP 要求的回應方式
        /// 藉由將Middleware新增到IApplicationBuilder 執行個體，就是可以設定管線
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                        //啟用開發人員例外狀況
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");     //例外處理時 導頁到Error 

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();                              //強制瀏覽器要使用HTTPS 造訪網站
            }

            app.UseHttpsRedirection();                  //重新以Https 導向網站

            app.UseStaticFiles();           //靜態檔案引入 CSS, Img ,js

            //會將Route參照加入Middleware , Middleware 會去依照useEndpoint所設定的位置依據Request 進行選擇最好的路由參照
            app.UseRouting();


            app.UseAuthorization();     //簡易授權

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
