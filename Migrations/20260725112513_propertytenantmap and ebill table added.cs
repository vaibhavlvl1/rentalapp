using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rental_system.Migrations
{
    /// <inheritdoc />
    public partial class propertytenantmapandebilltableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ebills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantMapId = table.Column<int>(type: "int", nullable: false),
                    PrevUnit = table.Column<double>(type: "float", nullable: false),
                    CurrentUnit = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CommonMeter = table.Column<double>(type: "float", nullable: false),
                    Utilities = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ebills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTenantMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    DateMovedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMovedOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTenantMap", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ebills");

            migrationBuilder.DropTable(
                name: "PropertyTenantMap");
        }
    }
}
