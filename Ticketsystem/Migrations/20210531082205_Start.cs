using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketsystem.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_CustomerId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerId1",
                table: "Ticket",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_CustomerId1",
                table: "Ticket",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_CustomerId1",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CustomerId1",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_CustomerId",
                table: "Ticket",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
