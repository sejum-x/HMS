using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addressfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId1",
                table: "Hospitals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AddressId1",
                table: "Hospitals",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Addresses_AddressId1",
                table: "Hospitals",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Addresses_AddressId1",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_AddressId1",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "Hospitals");
        }
    }
}
