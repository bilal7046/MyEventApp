using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEventApp.Data.Migrations
{
    public partial class createfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Rides",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_IdentityUserId",
                table: "Rides",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_AspNetUsers_IdentityUserId",
                table: "Rides",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_AspNetUsers_IdentityUserId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_IdentityUserId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Rides");
        }
    }
}
