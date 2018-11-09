using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Migrations
{
    public partial class _20181107_AdjustPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Persons_PersonId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_PersonId",
                table: "Managers");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ManagerId",
                table: "Persons",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Managers_ManagerId",
                table: "Persons",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Managers_ManagerId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ManagerId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Persons");

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
    }
}
