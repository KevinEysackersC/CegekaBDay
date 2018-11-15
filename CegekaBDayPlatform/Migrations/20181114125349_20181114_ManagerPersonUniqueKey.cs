using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Migrations
{
    public partial class _20181114_ManagerPersonUniqueKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Managers_PersonId",
                table: "Managers");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_PersonId",
                table: "Managers",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_PersonId",
                table: "Managers");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_PersonId",
                table: "Managers",
                column: "PersonId");
        }
    }
}
