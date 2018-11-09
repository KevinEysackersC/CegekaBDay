using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Migrations
{
    public partial class _20181109_AdjustTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_TemplateTypes_TypeId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_TypeId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Templates");

            migrationBuilder.AddColumn<Guid>(
                name: "TemplateTypeId",
                table: "Templates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TemplateTypeId",
                table: "Templates",
                column: "TemplateTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_TemplateTypes_TemplateTypeId",
                table: "Templates",
                column: "TemplateTypeId",
                principalTable: "TemplateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_TemplateTypes_TemplateTypeId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_TemplateTypeId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "TemplateTypeId",
                table: "Templates");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Templates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TypeId",
                table: "Templates",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_TemplateTypes_TypeId",
                table: "Templates",
                column: "TypeId",
                principalTable: "TemplateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
