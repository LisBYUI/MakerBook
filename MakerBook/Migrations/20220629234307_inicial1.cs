using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakerBook.Migrations
{
    public partial class inicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalAddressService",
                table: "ProfessionalAddressService");

            migrationBuilder.RenameTable(
                name: "ProfessionalAddressService",
                newName: "ProfessionalAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalAddress",
                table: "ProfessionalAddress",
                column: "ProfessionalAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalAddress",
                table: "ProfessionalAddress");

            migrationBuilder.RenameTable(
                name: "ProfessionalAddress",
                newName: "ProfessionalAddressService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalAddressService",
                table: "ProfessionalAddressService",
                column: "ProfessionalAddressId");
        }
    }
}
