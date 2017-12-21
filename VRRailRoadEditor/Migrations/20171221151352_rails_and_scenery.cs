using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRRailRoadEditor.Migrations
{
    public partial class rails_and_scenery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Tiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Tiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IMaterialID",
                table: "Tiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LayoutID",
                table: "Tiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IMaterial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMaterial", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IRail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IRail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IScenery",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ITileID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    PrimaryMaterialID = table.Column<int>(nullable: true),
                    RailID = table.Column<int>(nullable: true),
                    SecondaryMaterialID = table.Column<int>(nullable: true),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IScenery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IScenery_Tiles_ITileID",
                        column: x => x.ITileID,
                        principalTable: "Tiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IScenery_IMaterial_PrimaryMaterialID",
                        column: x => x.PrimaryMaterialID,
                        principalTable: "IMaterial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IScenery_IRail_RailID",
                        column: x => x.RailID,
                        principalTable: "IRail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IScenery_IMaterial_SecondaryMaterialID",
                        column: x => x.SecondaryMaterialID,
                        principalTable: "IMaterial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tiles_IMaterialID",
                table: "Tiles",
                column: "IMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Tiles_LayoutID",
                table: "Tiles",
                column: "LayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_IScenery_ITileID",
                table: "IScenery",
                column: "ITileID");

            migrationBuilder.CreateIndex(
                name: "IX_IScenery_PrimaryMaterialID",
                table: "IScenery",
                column: "PrimaryMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_IScenery_RailID",
                table: "IScenery",
                column: "RailID");

            migrationBuilder.CreateIndex(
                name: "IX_IScenery_SecondaryMaterialID",
                table: "IScenery",
                column: "SecondaryMaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_IMaterial_IMaterialID",
                table: "Tiles",
                column: "IMaterialID",
                principalTable: "IMaterial",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_IMaterial_IMaterialID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Layouts_LayoutID",
                table: "Tiles");

            migrationBuilder.DropTable(
                name: "IScenery");

            migrationBuilder.DropTable(
                name: "IMaterial");

            migrationBuilder.DropTable(
                name: "IRail");

            migrationBuilder.DropIndex(
                name: "IX_Tiles_IMaterialID",
                table: "Tiles");

            migrationBuilder.DropIndex(
                name: "IX_Tiles_LayoutID",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "IMaterialID",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "LayoutID",
                table: "Tiles");
        }
    }
}
