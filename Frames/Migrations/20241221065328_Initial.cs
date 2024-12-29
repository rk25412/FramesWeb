using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frames.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MasterFrameRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    WorkerFrameRate = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterFrameIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FrameCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFrameIns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterFrameOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFrameOuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterFrameOutTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrameTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    FrameRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    MasterFrameOutId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFrameOutTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterFrameOutTypes_FrameTypes_FrameTypeId",
                        column: x => x.FrameTypeId,
                        principalTable: "FrameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterFrameOutTypes_MasterFrameOuts_MasterFrameOutId",
                        column: x => x.MasterFrameOutId,
                        principalTable: "MasterFrameOuts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkerFrameIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoOfFrames = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFrameIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerFrameIns_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerFrameOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFrameOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerFrameOuts_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerFrameOutTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrameCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FrameTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    FrameRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    FrameOutId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFrameOutTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerFrameOutTypes_FrameTypes_FrameTypeId",
                        column: x => x.FrameTypeId,
                        principalTable: "FrameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerFrameOutTypes_WorkerFrameOuts_FrameOutId",
                        column: x => x.FrameOutId,
                        principalTable: "WorkerFrameOuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterFrameOutTypes_FrameTypeId",
                table: "MasterFrameOutTypes",
                column: "FrameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterFrameOutTypes_MasterFrameOutId",
                table: "MasterFrameOutTypes",
                column: "MasterFrameOutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFrameIns_WorkerId",
                table: "WorkerFrameIns",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFrameOuts_WorkerId",
                table: "WorkerFrameOuts",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFrameOutTypes_FrameOutId",
                table: "WorkerFrameOutTypes",
                column: "FrameOutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFrameOutTypes_FrameTypeId",
                table: "WorkerFrameOutTypes",
                column: "FrameTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterFrameIns");

            migrationBuilder.DropTable(
                name: "MasterFrameOutTypes");

            migrationBuilder.DropTable(
                name: "WorkerFrameIns");

            migrationBuilder.DropTable(
                name: "WorkerFrameOutTypes");

            migrationBuilder.DropTable(
                name: "MasterFrameOuts");

            migrationBuilder.DropTable(
                name: "FrameTypes");

            migrationBuilder.DropTable(
                name: "WorkerFrameOuts");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
