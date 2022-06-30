using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakerBook.Migrations
{
    public partial class inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId");
        }
    }
}
