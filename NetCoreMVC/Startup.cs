using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreMVC.Extensions;

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

            #region  Step 1 . Run
            //Run 只會執行此次MiddleWare , 並不會往下走
            //將多個要求委派鏈結在一起的方法是使用 Use
            //next 參數代表管線中的下個委派 ，委派不將要求傳遞到下一個委派時，這就是所謂讓要求管線短路。
            //app.Use(async (context, next) =>
            //  {
            //      await context.Response.WriteAsync("First Middleware in. \r\n");
            //      await next.Invoke();
            //      await context.Response.WriteAsync("First Middleware out. \r\n");
            //  });

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Second Middleware in. \r\n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("Second Middleware out. \r\n");
            //});


            //app.Use(async (context, next) =>
            //        {
            //            await context.Response.WriteAsync("Third Middleware in. \r\n");
            //            await next.Invoke();
            //            await context.Response.WriteAsync("Third Middleware out. \r\n");
            //        });

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello, Run World!  \r\n");
            //});


            #endregion  /Run

            #region Step 2. Use        

            /*
                        app.Use(async (context, next) =>
                        {
                            await context.Response.WriteAsync("First Middleware in. \r\n");
                            await next.Invoke();
                            await context.Response.WriteAsync("First Middleware out. \r\n");
                        });

                        app.Use(async (context, next) =>
                        {
                            await context.Response.WriteAsync("Second Middleware in. \r\n");

                            // 水管阻塞，封包不往後送
                            var condition = false;
                            if (condition)
                            {
                                //next 參數代表管線中的下個委派 ，委派不將要求傳遞到下一個委派時，這就是所謂讓要求管線短路。
                                await next.Invoke();
                            }

                            await context.Response.WriteAsync("Second Middleware out. \r\n");
                        });

                        app.Use(async (context, next) =>
                        {
                            await context.Response.WriteAsync("Third Middleware in. \r\n");
                            await next.Invoke();
                            await context.Response.WriteAsync("Third Middleware out. \r\n");
                        });

                        app.Run(async (context) =>
                        {
                            await context.Response.WriteAsync("Hello World! \r\n");
                        });
                        */
            #endregion /Use        

            #region  Step3. Map
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("First Middleware in. \r\n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("First Middleware out. \r\n");
            //});

            //app.Map("/second", mapApp =>
            //{
            //    mapApp.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Second Middleware in. \r\n");
            //        await next.Invoke();
            //        await context.Response.WriteAsync("Second Middleware out. \r\n");
            //    });
            //    mapApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Second. \r\n");
            //    });
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello World! \r\n");
            //});
            #endregion  /Map

            #region Step4. Extension 
            app.UseMiddleware<FirstMiddleware>();   //Custom Middleware
            app.UseFirstMiddleware();                             //Use Custom Middleware Extension 
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World! \r\n");
            });
            #endregion /Step4. Extension 

            #region ServiceFilter
            //app.UseMiddleware<MiddlewareService>(); 

            #endregion ServiceFilter

        }
    }
}
