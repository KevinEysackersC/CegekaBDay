using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Migrations
{
    public partial class _20181113_FixPersonManagerFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Managers_PersonId",
                table: "Managers",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Persons_PersonId",
                table: "Managers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Persons_PersonId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_PersonId",
                table: "Managers");
        }
    }
}
