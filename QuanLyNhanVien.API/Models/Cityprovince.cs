using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanVien.API.Models
{
    [Table("cityprovince")]
    public partial class Cityprovince
    {
        [Key]
        [Column("idCityProvince")]
        public int IdCityProvince { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }
    }
}