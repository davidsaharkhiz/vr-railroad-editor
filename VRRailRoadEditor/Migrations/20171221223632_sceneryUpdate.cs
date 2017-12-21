using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRRailRoadEditor.Migrations
{
    public partial class sceneryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IScenery_IMaterial_PrimaryMaterialID",
                table: "IScenery");

            migrationBuilder.DropForeignKey(
                name: "FK_IScenery_IMaterial_SecondaryMaterialID",
                table: "IScenery");

            migrationBuilder.DropIndex(
                name: "IX_IScenery_PrimaryMaterialID",
                table: "IScenery");

            migrationBuilder.DropIndex(
                name: "IX_IScenery_SecondaryMaterialID",
                table: "IScenery");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "PrimaryMaterialID",
                table: "IScenery");

            migrationBuilder.DropColumn(
                name: "SecondaryMaterialID",
                table: "IScenery");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryMaterialID",
                table: "Tiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryMaterialID",
                table: "Tiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Z",
                table: "Tiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Layouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Layouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Layouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tiles_PrimaryMaterialID",
                table: "Tiles",
                column: "PrimaryMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Tiles_SecondaryMaterialID",
                table: "Tiles",
                column: "SecondaryMaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_IMaterial_PrimaryMaterialID",
                table: "Tiles",
                column: "PrimaryMaterialID",
                principalTable: "IMaterial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_IMaterial_SecondaryMaterialID",
                table: "Tiles",
                column: "SecondaryMaterialID",
                principalTable: "IMaterial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_IMaterial_PrimaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_IMaterial_SecondaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropIndex(
                name: "IX_Tiles_PrimaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropIndex(
                name: "IX_Tiles_SecondaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "PrimaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "SecondaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "Z",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Layouts");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Layouts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryMaterialID",
                table: "IScenery",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryMaterialID",
                table: "IScenery",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IScenery_PrimaryMaterialID",
                table: "IScenery",
                column: "PrimaryMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_IScenery_SecondaryMaterialID",
                table: "IScenery",
                column: "SecondaryMaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_IScenery_IMaterial_PrimaryMaterialID",
                table: "IScenery",
                column: "PrimaryMaterialID",
                principalTable: "IMaterial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IScenery_IMaterial_SecondaryMaterialID",
                table: "IScenery",
                column: "SecondaryMaterialID",
                principalTable: "IMaterial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
