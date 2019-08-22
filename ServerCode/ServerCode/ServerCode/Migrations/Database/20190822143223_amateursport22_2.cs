using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerCode.Migrations.Database
{
    public partial class amateursport22_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserForum_Forums_ForumId",
                table: "UserForum");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForum_AspNetUsers_UserId",
                table: "UserForum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForum",
                table: "UserForum");

            migrationBuilder.RenameTable(
                name: "UserForum",
                newName: "UserForums");

            migrationBuilder.RenameIndex(
                name: "IX_UserForum_UserId",
                table: "UserForums",
                newName: "IX_UserForums_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserForum_ForumId",
                table: "UserForums",
                newName: "IX_UserForums_ForumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForums",
                table: "UserForums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserForums_Forums_ForumId",
                table: "UserForums",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForums_AspNetUsers_UserId",
                table: "UserForums",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserForums_Forums_ForumId",
                table: "UserForums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForums_AspNetUsers_UserId",
                table: "UserForums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForums",
                table: "UserForums");

            migrationBuilder.RenameTable(
                name: "UserForums",
                newName: "UserForum");

            migrationBuilder.RenameIndex(
                name: "IX_UserForums_UserId",
                table: "UserForum",
                newName: "IX_UserForum_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserForums_ForumId",
                table: "UserForum",
                newName: "IX_UserForum_ForumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForum",
                table: "UserForum",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserForum_Forums_ForumId",
                table: "UserForum",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForum_AspNetUsers_UserId",
                table: "UserForum",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
