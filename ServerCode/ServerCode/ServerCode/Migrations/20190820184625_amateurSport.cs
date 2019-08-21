using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerCode.Migrations
{
    public partial class amateurSport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Ranking = table.Column<int>(nullable: false),
                    ExtraInformation = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    SportType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    LevelUser = table.Column<int>(nullable: false),
                    AgeRange = table.Column<int>(nullable: false),
                    ExtraInformation = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementsHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vaule = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportName_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Localization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    AdvertisementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localization_AdvertisementsHistory_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "AdvertisementsHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdvertisementsHistory",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdvertisementsHistory", x => new { x.UserId, x.AdvertisementId });
                    table.ForeignKey(
                        name: "FK_UserAdvertisementsHistory_AdvertisementsHistory_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "AdvertisementsHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdvertisementsHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdvertisementsHistory_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_UserId",
                table: "Achievement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementsHistory_UserId",
                table: "AdvertisementsHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Localization_AdvertisementId",
                table: "Localization",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportName_UserId",
                table: "SportName",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisementsHistory_AdvertisementId",
                table: "UserAdvertisementsHistory",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisementsHistory_UserId1",
                table: "UserAdvertisementsHistory",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Localization");

            migrationBuilder.DropTable(
                name: "SportName");

            migrationBuilder.DropTable(
                name: "UserAdvertisementsHistory");

            migrationBuilder.DropTable(
                name: "AdvertisementsHistory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
