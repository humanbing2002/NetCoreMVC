using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetCoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //�I�s�إ�Host���{��
            //.Build()  �I�sWebHostBuilder , �i���Ҥ�
            //.Run()    �Ұ� WebHost�C
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///�ΨӱҰ� WebHost�F
        ///WebHost �N�O ASP.NET Core ���������� 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>

        #region �z�L����k�إ� WebHost Builder�CWebHost Builder �O�ΨӲ��� WebHost ������C
        //Host.CreateDefaultBuilder(args)             
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>(); //Startup �OWebHost�Ұʫ�A�n���檺���O
        //    });
        #endregion

        #region �]�i�H���nStratUp , �i�H�����bProgram���إߩһݭn���]�w
        //Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder
        //               .ConfigureServices(services =>
        //               {
        //                   // Web Host ���U Services ...
        //               })
        //               .Configure(app =>
        //               {
        //                   app.UseRouting();
        //                   app.UseEndpoints(endpoints =>
        //                   {
        //                       endpoints.MapGet("/",
        //                           async context =>
        //                           {
        //                               await context.Response.WriteAsync("Hello World!");
        //                           });
        //                   });
        //               });
        //        });
        #endregion


        Host.CreateDefaultBuilder(args)
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<CustomStartup>();
             });
    }
}
