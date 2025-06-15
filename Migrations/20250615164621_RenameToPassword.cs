using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iggybank_app.Migrations
{
    /// <inheritdoc />
    public partial class RenameToPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "PasswordHash");
        }
    }
}
