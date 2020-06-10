using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanVien.API.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cityprovince> Cityprovince { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
    }
}