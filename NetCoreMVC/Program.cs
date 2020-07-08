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
            //呼叫建立Host的程式
            //.Build()  呼叫WebHostBuilder , 進行實例化
            //.Run()    啟動 WebHost。
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///用來啟動 WebHost；
        ///WebHost 就是 ASP.NET Core 的網站實體 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>

        #region 透過此方法建立 WebHost Builder。WebHost Builder 是用來產生 WebHost 的物件。
        //Host.CreateDefaultBuilder(args)             
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>(); //Startup 是WebHost啟動後，要執行的類別
        //    });
        #endregion

        #region 也可以不要StratUp , 可以直接在Program中建立所需要的設定
        //Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder
        //               .ConfigureServices(services =>
        //               {
        //                   // Web Host 註冊 Services ...
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
