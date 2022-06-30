using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakerBook.Migrations
{
    public partial class inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalAddress_Professional_ProfessionalId",
                table: "ProfessionalAddress");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionalId",
                table: "ProfessionalAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalAddress_Professional_ProfessionalId",
                table: "ProfessionalAddress",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalAddress_Professional_ProfessionalId",
                table: "ProfessionalAddress");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionalId",
                table: "ProfessionalAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalAddress_Professional_ProfessionalId",
                table: "ProfessionalAddress",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "ProfessionalId");
        }
    }
}
