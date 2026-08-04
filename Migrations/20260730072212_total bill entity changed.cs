using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rental_system.Migrations
{
    /// <inheritdoc />
    public partial class totalbillentitychanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Ebill",
                table: "MonthlyBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ebill",
                table: "MonthlyBills");
        }
    }
}
