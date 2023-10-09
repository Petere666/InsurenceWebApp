using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsurenceWebApp.Data.Migrations
{
    public partial class UsersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BirthDate = table.Column<int>(type: "date", nullable: false),
                    Age = table.Column<int>(type: "tinyint", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TelephoneNumber = table.Column<int>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
