using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rental_system.Migrations
{
    /// <inheritdoc />
    public partial class addedroomtoaddpropertyentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomNo",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomNo",
                table: "Properties");
        }
    }
}
