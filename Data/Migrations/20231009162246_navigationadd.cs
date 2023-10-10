using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsurenceWebApp.Data.Migrations
{
    public partial class navigationadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsurancesId",
                table: "InsurancesEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Insurances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsurancesEvents_InsurancesId",
                table: "InsurancesEvents",
                column: "InsurancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_UserId",
                table: "Insurances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Users_UserId",
                table: "Insurances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancesEvents_Insurances_InsurancesId",
                table: "InsurancesEvents",
                column: "InsurancesId",
                principalTable: "Insurances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Users_UserId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancesEvents_Insurances_InsurancesId",
                table: "InsurancesEvents");

            migrationBuilder.DropIndex(
                name: "IX_InsurancesEvents_InsurancesId",
                table: "InsurancesEvents");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_UserId",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "InsurancesId",
                table: "InsurancesEvents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Insurances");
        }
    }
}
