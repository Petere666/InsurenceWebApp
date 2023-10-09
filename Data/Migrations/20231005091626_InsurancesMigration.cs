using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsurenceWebApp.Data.Migrations
{
    public partial class InsurancesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ContractNumber = table.Column<int>(type: "int", nullable: false),
                    MonthPayment = table.Column<int>(type: "money", nullable: false),
                    Principal = table.Column<int>(type: "money", nullable: false),
                    Validity = table.Column<int>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurances");
        }
    }
}
