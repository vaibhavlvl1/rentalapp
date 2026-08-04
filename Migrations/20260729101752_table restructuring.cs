using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rental_system.Migrations
{
    /// <inheritdoc />
    public partial class tablerestructuring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ebills");

            migrationBuilder.CreateTable(
                name: "MonthlyBills",
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
                    RoomRent = table.Column<double>(type: "float", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    RentPaid = table.Column<bool>(type: "bit", nullable: true),
                    EbillPaid = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBills", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyBills");

            migrationBuilder.CreateTable(
                name: "Ebills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonMeter = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentUnit = table.Column<double>(type: "float", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrevUnit = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    TenantMapId = table.Column<int>(type: "int", nullable: false),
                    Utilities = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ebills", x => x.Id);
                });
        }
    }
}
