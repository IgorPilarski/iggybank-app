using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iggybank_app.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameColumnToTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Transactions");
        }
    }
}
