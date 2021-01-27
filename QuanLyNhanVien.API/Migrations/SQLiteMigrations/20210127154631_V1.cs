using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhanVien.API.Migrations.SQLiteMigrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cityprovince",
                columns: table => new
                {
                    idCityProvince = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityprovince", x => x.idCityProvince);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    idEmployees = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 40, nullable: true),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Title = table.Column<string>(maxLength: 45, nullable: true),
                    TitleOfCourtesy = table.Column<string>(maxLength: 10, nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 80, nullable: true),
                    CityDistrict = table.Column<string>(maxLength: 45, nullable: true),
                    CityProvince = table.Column<string>(maxLength: 45, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    PhotoPath = table.Column<string>(maxLength: 255, nullable: true),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.idEmployees);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityprovince");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
