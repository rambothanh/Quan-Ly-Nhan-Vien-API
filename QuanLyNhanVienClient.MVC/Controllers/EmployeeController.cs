using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLyNhanVienClient.MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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

        //Click vào nút sửa ở từng nhân viên sẽ chuyển đến trang Update
        // /employee/update/{id}
        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            //Thực hiện gọi API
            HttpResponseMessage reponse = await client.GetAsync($"{employeesApiUrl}/{id}");
            //Đọc nội dung trả về chuyển thành chuỗi JSon
            string stringJsonData = await reponse.Content.ReadAsStringAsync();
            //Chuyển chuỗi Json thành đối tượng employee
            var op = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Employee modelEmployee = JsonSerializer.Deserialize<Employee>(stringJsonData, op);
            return View(modelEmployee);
        }

        //Click nút Lưu ở trang chỉnh sửa
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Employee modelEmployee)
        {
            //Kiểm tra xác thực của model một lần nữa bằng ModelState
            if (ModelState.IsValid)
            {
                //Chuyển model thành chuỗi json
                string stringJsonData = JsonSerializer.Serialize(modelEmployee);
                //Chuẩn bị nội dung HTTP
                var httpContent = new StringContent(stringJsonData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{employeesApiUrl}/{modelEmployee.IdEmployees}", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.alertsuccess = "Đã lưu chỉnh sửa";
                }
                else
                {
                    ViewBag.alertfail = "Có lỗi trong việc gọi API";
                }

            }
            return View(modelEmployee);
        }
        //Click vào nút thêm ở trang danh sách nhân viên sẽ chuyển để trang Insert
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        //Submit Form sẽ thực hiện action Insert này
        [HttpPost]
        public async Task<IActionResult> InsertAsync(Employee modelEmployee)
        {
            if (ModelState.IsValid)
            {
                //Chuyển đổi giá trị của một loại(type) được chỉ định thành một chuỗi JSON.
                string stringJsonData = JsonSerializer.Serialize(modelEmployee);
                //StringContent Cung cấp nội dung HTTP dựa trên một chuỗi.
                //StringContent có 3 phương thức khởi tạo
                //Dùng phương thức có 3 tham số:
                //Tham số thứ 1 là chuỗi để khởi tạo StringContent
                //Tham số thứ 2 để thực hiện mã hoá UTF8
                //Tham số thứ 3 chỉ định chuỗi mediaType
                var httpContent = new StringContent(stringJsonData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(employeesApiUrl, httpContent);

                //kiểm tra thuộc tính IsSuccessStatusCode của response
                //để xác định xem lệnh gọi API có thành công hay không.
                //Thuộc tính IsSuccessStatusCode trả về true nếu mã trạng thái HTTP
                //của phản hồi nằm trong phạm vi200–299, ngoài ra nó trả về false
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.alertsuccess = "Thêm nhân viên mới thành công";
                }
                else
                {
                    ViewBag.alertfail = "Có lỗi trong việc gọi API";
                }
            }
            return View(modelEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(employeesApiUrl);

                //Phương thức ReadAsStringAsync() đọc chuỗi Json
                //từ đối tượng dạng HttpResponseMessage
                string stringJsonData = await response.Content.ReadAsStringAsync();
                //ViewBag.datatest = stringData;

                //Để chuyển đổi nội dung Json sang dạng List<Employee>
                //Dùng phương thức Deserialize() của lớp JsonSerializer
                //Deserialize() có tham số thứ nhất là chuỗi Json
                //tham số thứ 2 là cấu hình, chuẩn bị cấu hình:
                var options = new JsonSerializerOptions
                {
                    //phân biệt chữ hoa chữ thường
                    PropertyNameCaseInsensitive = true
                };

                //Sử dụng Deserialize()
                List<Employee> data = JsonSerializer.Deserialize<List<Employee>>(stringJsonData, options);
                return View(data);
                //ViewBag.stringData = stringData;
                //return View();
            }
            catch { return View(); };
        }
    }
}