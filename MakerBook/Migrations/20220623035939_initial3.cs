using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakerBook.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSocialMedia_ProfessionalProfileId",
                table: "ProfessionalSocialMedia",
                column: "ProfessionalProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalProfile_ProfessionalId",
                table: "ProfessionalProfile",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalProfile_Professional_ProfessionalId",
                table: "ProfessionalProfile",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalSocialMedia_ProfessionalProfile_ProfessionalProfileId",
                table: "ProfessionalSocialMedia",
                column: "ProfessionalProfileId",
                principalTable: "ProfessionalProfile",
                principalColumn: "ProfessionalProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalProfile_Professional_ProfessionalId",
                table: "ProfessionalProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalSocialMedia_ProfessionalProfile_ProfessionalProfileId",
                table: "ProfessionalSocialMedia");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalSocialMedia_ProfessionalProfileId",
                table: "ProfessionalSocialMedia");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalProfile_ProfessionalId",
                table: "ProfessionalProfile");
        }
    }
}
