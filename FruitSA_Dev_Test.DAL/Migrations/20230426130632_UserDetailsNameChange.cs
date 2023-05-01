using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitSA_Dev_Test.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserDetailsNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterUserModel",
                table: "RegisterUserModel");

            migrationBuilder.RenameTable(
                name: "RegisterUserModel",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "RegisterUserModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterUserModel",
                table: "RegisterUserModel",
                column: "Id");
        }
    }
}
