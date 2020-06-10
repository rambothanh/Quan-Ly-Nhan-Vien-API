using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace QuanLyNhanVienClient.MVC
{
    public class Startup
    {
        private IConfiguration config = null;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            HttpClient client = new HttpClient();
            string baseUrl = config.GetValue<String>("AppSettings:BaseUrl");
            //Định nghĩa địa chỉ cơ sở của API bằng BaseAddress của lớp HttpClient
            client.BaseAddress = new Uri(baseUrl);
            //Định nghĩa máy khách cần dữ liệu ở định dạng JSON (không phải XML)
            //MediaTypeWithQualityHeaderValue (trong lớp .Net.Http.Headers)
            //chỉ định loại nội dụng dữ liệu trả về
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            //Đăng ký client với hệ thống DI bằng phương thức AddSingleton<T>()
            //AddSingleton chỉ ra rằng chỉ 1 phiên bản HTTPClient (client)
            //sẽ phục vụ tất cả các yêu cấu đến đối tượng.
            services.AddSingleton<HttpClient>(client);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=List}/{id?}"
                    );
            });
        }
    }
}