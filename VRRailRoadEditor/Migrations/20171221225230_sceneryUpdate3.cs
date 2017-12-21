using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRRailRoadEditor.Migrations
{
    public partial class sceneryUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IScenery_IRail_RailID",
                table: "IScenery");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_IMaterial_PrimaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_IMaterial_SecondaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_IMaterial_IMaterialID",
                table: "Tiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IRail",
                table: "IRail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IMaterial",
                table: "IMaterial");

            migrationBuilder.RenameTable(
                name: "IRail",
                newName: "Rails");

            migrationBuilder.RenameTable(
                name: "IMaterial",
                newName: "Materials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rails",
                table: "Rails",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IScenery_Rails_RailID",
                table: "IScenery",
                column: "RailID",
                principalTable: "Rails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Materials_PrimaryMaterialID",
                table: "Tiles",
                column: "PrimaryMaterialID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Materials_SecondaryMaterialID",
                table: "Tiles",
                column: "SecondaryMaterialID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Materials_IMaterialID",
                table: "Tiles",
                column: "IMaterialID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IScenery_Rails_RailID",
                table: "IScenery");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Materials_PrimaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Materials_SecondaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Materials_IMaterialID",
                table: "Tiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rails",
                table: "Rails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.RenameTable(
                name: "Rails",
                newName: "IRail");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "IMaterial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IRail",
                table: "IRail",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IMaterial",
                table: "IMaterial",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IScenery_IRail_RailID",
                table: "IScenery",
                column: "RailID",
                principalTable: "IRail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_IMaterial_IMaterialID",
                table: "Tiles",
                column: "IMaterialID",
                principalTable: "IMaterial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
