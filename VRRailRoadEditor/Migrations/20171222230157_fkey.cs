using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRRailRoadEditor.Migrations
{
    public partial class fkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_ILayout_LayoutID",
                table: "Tiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ILayout",
                table: "ILayout");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ILayout");

            migrationBuilder.RenameTable(
                name: "ILayout",
                newName: "Layouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Layouts_LayoutID",
                table: "Tiles",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Layouts_LayoutID",
                table: "Tiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts");

            migrationBuilder.RenameTable(
                name: "Layouts",
                newName: "ILayout");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Materials",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ILayout",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ILayout",
                table: "ILayout",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_ILayout_LayoutID",
                table: "Tiles",
                column: "LayoutID",
                principalTable: "ILayout",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
