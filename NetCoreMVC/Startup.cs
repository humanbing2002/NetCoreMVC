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
        //����k�O�ΨӱN�A�ȵ��U�� DI �e���Ϊ�    
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// �Ψӫ��w���ε{���� HTTP �n�D���^���覡
        /// �ǥѱNMiddleware�s�W��IApplicationBuilder �������A�N�O�i�H�]�w�޽u
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            #region  Step 1 . Run
            //Run �u�|���榹��MiddleWare , �ä��|���U��
            //�N�h�ӭn�D�e���쵲�b�@�_����k�O�ϥ� Use
            //next �ѼƥN��޽u�����U�өe�� �A�e�����N�n�D�ǻ���U�@�өe���ɡA�o�N�O�ҿ����n�D�޽u�u���C
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

                            // ���ު���A�ʥ]������e
                            var condition = false;
                            if (condition)
                            {
                                //next �ѼƥN��޽u�����U�өe�� �A�e�����N�n�D�ǻ���U�@�өe���ɡA�o�N�O�ҿ����n�D�޽u�u���C
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
