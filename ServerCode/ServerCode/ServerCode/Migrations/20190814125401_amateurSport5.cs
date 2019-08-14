using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerCode.Migrations
{
    public partial class amateurSport5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateSendMessage",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateSendMessage",
                table: "Messages");
        }
    }
}
