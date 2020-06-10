using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanVienClient.MVC.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Mã nhân viên")]
        [Key]
        [Column("idEmployees")]
        public int IdEmployees { get; set; }

        [Required(ErrorMessage = "Chưa cung cấp Tên nhân viên")]
        [Display(Name = "Tên")]
        [StringLength(20, ErrorMessage = "Tên không quá 20 ký tự")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Chưa cung cấp Họ nhân viên")]
        [Display(Name = "Họ")]
        [StringLength(20, ErrorMessage = "Họ không quá 20 ký tự")]
        public string LastName { get; set; }

        [Display(Name = "Họ lót")]
        [StringLength(40, ErrorMessage = "Họ lót không quá 40 ký tự")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Chưa cung số điện thoại")]
        [Display(Name = "Điện thoại")]
        [StringLength(10, ErrorMessage = "Điện thoại 10 số")]
        public string Phone { get; set; }

        [Display(Name = "Chức vụ")]
        [StringLength(45, ErrorMessage = "Chức vụ không quá 45 ký tự")]
        public string Title { get; set; }

        [Display(Name = "Danh xưng")]
        [StringLength(10, ErrorMessage = "Danh xưng không quá 19 ký tự")]
        public string TitleOfCourtesy { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Ngày ký hợp đồng")]
        public DateTime? HireDate { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(80, ErrorMessage = "Địa chỉ không quá 80 ký tự")]
        public string Address { get; set; }

        [Display(Name = "Tỉnh/Thành phố")]
        [StringLength(45, ErrorMessage = "Tỉnh/Thành phố không quá 45 ký tự")]
        public string CityDistrict { get; set; }

        [Display(Name = "Tỉnh/Thành phố")]
        [StringLength(45, ErrorMessage = "Huyện/Thành phố không quá 45 ký tự")]
        public string CityProvince { get; set; }

        [Display(Name = "Mã bưu chính")]
        [StringLength(10, ErrorMessage = "Mã bưu chính không quá 10 ký tự")]
        public string PostalCode { get; set; }

        [Display(Name = "Quốc tịch")]
        [StringLength(10, ErrorMessage = "Quốc tịch không quá 15 ký tự")]
        public string Country { get; set; }

        [Display(Name = "Đường dẫn ảnh")]
        [StringLength(255, ErrorMessage = "Đường dẫn ảnh không quá 255 ký tự")]
        public string PhotoPath { get; set; }

        [Display(Name = "Ghi chú")]
        [Column(TypeName = "longtext")]
        public string Notes { get; set; }
    }
}