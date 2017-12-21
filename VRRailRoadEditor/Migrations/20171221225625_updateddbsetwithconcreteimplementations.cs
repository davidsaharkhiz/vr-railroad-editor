using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRRailRoadEditor.Migrations
{
    public partial class updateddbsetwithconcreteimplementations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IScenery_Tiles_ITileID",
                table: "IScenery");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Layouts_LayoutID",
                table: "Tiles");

            migrationBuilder.DropIndex(
                name: "IX_Tiles_PrimaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropIndex(
                name: "IX_Tiles_SecondaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rails",
                table: "Rails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "PrimaryMaterialID",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "SecondaryMaterialID",
                table: "Tiles");

            migrationBuilder.RenameTable(
                name: "Rails",
                newName: "IRail");

            migrationBuilder.RenameTable(
                name: "Layouts",
                newName: "ILayout");

            migrationBuilder.RenameColumn(
                name: "IMaterialID",
                table: "Tiles",
                newName: "MaterialID");

            migrationBuilder.RenameIndex(
                name: "IX_Tiles_IMaterialID",
                table: "Tiles",
                newName: "IX_Tiles_MaterialID");

            migrationBuilder.RenameColumn(
                name: "ITileID",
                table: "IScenery",
                newName: "TileID");

            migrationBuilder.RenameIndex(
                name: "IX_IScenery_ITileID",
                table: "IScenery",
                newName: "IX_IScenery_TileID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "IRail",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ILayout",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IRail",
                table: "IRail",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ILayout",
                table: "ILayout",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IScenery_IRail_RailID",
                table: "IScenery",
                column: "RailID",
                principalTable: "IRail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IScenery_Tiles_TileID",
                table: "IScenery",
                column: "TileID",
                principalTable: "Tiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_ILayout_LayoutID",
                table: "Tiles",
                column: "LayoutID",
                principalTable: "ILayout",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Materials_MaterialID",
                table: "Tiles",
                column: "MaterialID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IScenery_IRail_RailID",
                table: "IScenery");

            migrationBuilder.DropForeignKey(
                name: "FK_IScenery_Tiles_TileID",
                table: "IScenery");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_ILayout_LayoutID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Materials_MaterialID",
                table: "Tiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IRail",
                table: "IRail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ILayout",
                table: "ILayout");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "IRail");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ILayout");

            migrationBuilder.RenameTable(
                name: "IRail",
                newName: "Rails");

            migrationBuilder.RenameTable(
                name: "ILayout",
                newName: "Layouts");

            migrationBuilder.RenameColumn(
                name: "MaterialID",
                table: "Tiles",
                newName: "IMaterialID");

            migrationBuilder.RenameIndex(
                name: "IX_Tiles_MaterialID",
                table: "Tiles",
                newName: "IX_Tiles_IMaterialID");

            migrationBuilder.RenameColumn(
                name: "TileID",
                table: "IScenery",
                newName: "ITileID");

            migrationBuilder.RenameIndex(
                name: "IX_IScenery_TileID",
                table: "IScenery",
                newName: "IX_IScenery_ITileID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Tiles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryMaterialID",
                table: "Tiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryMaterialID",
                table: "Tiles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rails",
                table: "Rails",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tiles_PrimaryMaterialID",
                table: "Tiles",
                column: "PrimaryMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Tiles_SecondaryMaterialID",
                table: "Tiles",
                column: "SecondaryMaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_IScenery_Tiles_ITileID",
                table: "IScenery",
                column: "ITileID",
                principalTable: "Tiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Layouts_LayoutID",
                table: "Tiles",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
