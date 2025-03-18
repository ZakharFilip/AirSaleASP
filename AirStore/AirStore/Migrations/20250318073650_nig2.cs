using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirStore.Migrations
{
    /// <inheritdoc />
    public partial class nig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleIdRole",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleIdRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleIdRole",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdRole",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleIdRole",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleIdRole",
                table: "Users",
                column: "RoleIdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleIdRole",
                table: "Users",
                column: "RoleIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole");
        }
    }
}
