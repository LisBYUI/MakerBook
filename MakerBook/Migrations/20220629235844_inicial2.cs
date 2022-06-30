using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakerBook.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_ServiceId",
                table: "ServiceAddress",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalAddress_ProfessionalId",
                table: "ProfessionalAddress",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalAddress_Professional_ProfessionalId",
                table: "ProfessionalAddress",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalAddress_Professional_ProfessionalId",
                table: "ProfessionalAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAddress_ServiceId",
                table: "ServiceAddress");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalAddress_ProfessionalId",
                table: "ProfessionalAddress");
        }
    }
}
