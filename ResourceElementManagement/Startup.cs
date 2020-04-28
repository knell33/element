using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REMCommon;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace ResourceElementManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(o => o.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //����
            services.AddMemoryCache();
            services.AddSession();

            //����һ��������Դ���Կ���
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // �趨����������Դ���ж��������','����
                    policy.WithOrigins("http://localhost:8081","http://localhost:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });

            //��־��������
            services.AddMvc(options =>
            {
                options.Filters.Add(new ActionFilter());
                options.Filters.Add(new ExceptionFilter());
            });
            });
            //ע��swagger����
            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ResourceElementManagementAPI",
                    Version = "v1"
                });

                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
                var xmlPath = Path.Combine(basePath, "ResourceElementManagement.xml");
                m.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //��������
            SiteConfig.SetOracleConn(Configuration["OracleConn"]);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //ʹ�þ�̬�ļ�
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //���û���
            app.UseCookiePolicy();
            app.UseSession();

            //����
            app.UseCors("CustomCorsPolicy");

            //����swagger����
            app.UseSwagger();
            app.UseSwaggerUI(
                m =>
                {
                    m.SwaggerEndpoint("/swagger/v1/swagger.json", "ResourceElementManagement");
                }
             );

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
