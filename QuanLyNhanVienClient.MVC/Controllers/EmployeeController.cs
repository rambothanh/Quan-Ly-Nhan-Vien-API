using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLyNhanVienClient.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace QuanLyNhanVienClient.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient client = null;
        private string employeesApiUrl = "";
        public EmployeeController(HttpClient client, IConfiguration config)
        {
            this.client = client;
            this.employeesApiUrl = config.GetValue<string>("AppSettings:EmployeesApiUrl");

        }

        public async Task<IActionResult> ListAsync()
        {
            HttpResponseMessage response = await client.GetAsync(employeesApiUrl);
            //Phương thức ReadAsStringAsync() đọc chuỗi Json 
            //từ đối tượng dạng HttpResponseMessage
            string stringData = await response.Content.ReadAsStringAsync();
            ViewBag.datatest = stringData;
            //Để chuyển đổi nội dung Json sang dạng List<Employee>
            //Dùng phương thức Deserialize() của lớn JsonSerializer
            //Deserialize() có tham số thứ nhất là chuỗi Json
            //tham số thứ 2 là cấu hình, chuẩn bị cấu hình:
            var options = new JsonSerializerOptions
            {
                //phân biệt chữ hoa chữ thường
                PropertyNameCaseInsensitive = true
            };

            //Sử dụng Deserialize()
            List<Employee> data = JsonSerializer.Deserialize<List<Employee>>(stringData, options);
            return View(data);
            //ViewBag.stringData = stringData;
            //return View();

        }

        public IActionResult Insert()
        {
            return View();
        }

    }


}