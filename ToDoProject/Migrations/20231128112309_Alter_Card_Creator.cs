using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoProject.Migrations
{
    public partial class Alter_Card_Creator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_CreatorId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_CreatorId",
                table: "Cards",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_CreatorId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_CreatorId",
                table: "Cards",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
