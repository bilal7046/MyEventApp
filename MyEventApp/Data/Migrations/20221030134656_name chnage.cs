using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEventApp.Data.Migrations
{
    public partial class namechnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_Member_MemberID",
                table: "Entry");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_AspNetUsers_IdentityUserId",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ride",
                table: "Ride");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entry",
                table: "Entry");

            migrationBuilder.RenameTable(
                name: "Ride",
                newName: "Rides");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "Entry",
                newName: "Entries");

            migrationBuilder.RenameIndex(
                name: "IX_Member_IdentityUserId",
                table: "Members",
                newName: "IX_Members_IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Entry_MemberID",
                table: "Entries",
                newName: "IX_Entries_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rides",
                table: "Rides",
                column: "RideID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                table: "Entries",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Members_MemberID",
                table: "Entries",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_IdentityUserId",
                table: "Members",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Members_MemberID",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_IdentityUserId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rides",
                table: "Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                table: "Entries");

            migrationBuilder.RenameTable(
                name: "Rides",
                newName: "Ride");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameTable(
                name: "Entries",
                newName: "Entry");

            migrationBuilder.RenameIndex(
                name: "IX_Members_IdentityUserId",
                table: "Member",
                newName: "IX_Member_IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_MemberID",
                table: "Entry",
                newName: "IX_Entry_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ride",
                table: "Ride",
                column: "RideID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entry",
                table: "Entry",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_Member_MemberID",
                table: "Entry",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_AspNetUsers_IdentityUserId",
                table: "Member",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
