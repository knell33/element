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

            //缓存
            services.AddMemoryCache();
            services.AddSession();

            //允许一个或多个来源可以跨域
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // 设定允许跨域的来源，有多个可以用','隔开
                    policy.WithOrigins("http://localhost:8081","http://localhost:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });

            //日志及错误处理
            services.AddMvc(options =>
            {
                options.Filters.Add(new ActionFilter());
                options.Filters.Add(new ExceptionFilter());
            });
            });
            //注册swagger服务
            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ResourceElementManagementAPI",
                    Version = "v1"
                });

                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "ResourceElementManagement.xml");
                m.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //配置连接
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

            //使用静态文件
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //启用缓存
            app.UseCookiePolicy();
            app.UseSession();

            //跨域
            app.UseCors("CustomCorsPolicy");

            //引用swagger服务
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
