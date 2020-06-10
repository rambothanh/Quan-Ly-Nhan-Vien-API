using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanVien.API.Models
{
    [Table("employees")]
    public partial class Employees
    {
        [Key]
        [Column("idEmployees")]
        public int IdEmployees { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(40)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [StringLength(45)]
        public string Title { get; set; }
        [StringLength(10)]
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? HireDate { get; set; }
        [StringLength(80)]
        public string Address { get; set; }
        [StringLength(45)]
        public string CityDistrict { get; set; }
        [StringLength(45)]
        public string CityProvince { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }
        [Column(TypeName = "longtext")]
        public string Notes { get; set; }
    }
}
