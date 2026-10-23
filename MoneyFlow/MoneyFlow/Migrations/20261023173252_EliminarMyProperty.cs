using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyFlow.Migrations
{
    /// <inheritdoc />
    public partial class EliminarMyProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Transaction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
