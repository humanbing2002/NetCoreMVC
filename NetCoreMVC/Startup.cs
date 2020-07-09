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
        //����k�O�ΨӱN�A�ȵ��U�� DI �e���Ϊ�    
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
          
            services.AddTransient<ISampleTransient, LifeCycleSample>();
            services.AddScoped<ISampleScoped, LifeCycleSample>();
            services.AddSingleton<ISampleSingleton, LifeCycleSample>();


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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                        //�ҥζ}�o�H���ҥ~���p
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");     //�ҥ~�B�z�� �ɭ���Error 

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();                              //�j���s�����n�ϥ�HTTPS �y�X����
            }

            app.UseHttpsRedirection();                  //���s�HHttps �ɦV����

            app.UseStaticFiles();           //�R�A�ɮפޤJ CSS, Img ,js

            //�|�NRoute�ѷӥ[�JMiddleware , Middleware �|�h�̷�useEndpoint�ҳ]�w����m�̾�Request �i���̦ܳn�����Ѱѷ�
            app.UseRouting();


            app.UseAuthorization();     //²�����v

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
