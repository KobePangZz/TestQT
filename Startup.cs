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
using WebApplication1.Config;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http;
using WebApplication1.Model;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        /// <summary>
        /// </summary>
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //��ӱ���·����ȡ֧��
            services.AddSingleton(new AppSettingsHelper(Env.ContentRootPath));
            //services.Configure<List<SequenceOption>>(Configuration.GetSection("Sequence"));

            //���ÿ���CORS��
            services.AddCorsSetup();
            //ע��mvc��ע��razor������ͼ
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
                .AddNewtonsoftJson(p =>
                {
                    //���ݸ�ʽ����ĸСд ��ʹ���շ�
                    p.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    //��ʹ���շ���ʽ��key
                    //p.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //����ѭ������
                    p.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //����ʱ���ʽ
                    p.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // CORS����
            app.UseCors(AppSettingsConstVars.CorsPolicyName);

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            // ���ش�����
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
