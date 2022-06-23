using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakerBook.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessionalProfile",
                columns: table => new
                {
                    ProfessionalProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    ImageProfile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalProfile", x => x.ProfessionalProfileId);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalSocialMedia",
                columns: table => new
                {
                    ProfessionalSocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalProfileId = table.Column<int>(type: "int", nullable: false),
                    SocialMedia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalProfileType = table.Column<int>(type: "int", nullable: false),
                    UserAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSocialMedia", x => x.ProfessionalSocialMediaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalProfile");

            migrationBuilder.DropTable(
                name: "ProfessionalSocialMedia");
        }
    }
}
