using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyFlow.Migrations
{
    /// <inheritdoc />
    public partial class Commentsolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Commment",
                table: "Transaction",
                newName: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Transaction",
                newName: "Commment");
        }
    }
}
