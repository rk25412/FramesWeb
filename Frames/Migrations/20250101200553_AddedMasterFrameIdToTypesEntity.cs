using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frames.Migrations
{
    /// <inheritdoc />
    public partial class AddedMasterFrameIdToTypesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterFrameOutTypes_MasterFrameOuts_MasterFrameOutId",
                table: "MasterFrameOutTypes");

            migrationBuilder.AlterColumn<int>(
                name: "MasterFrameOutId",
                table: "MasterFrameOutTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterFrameOutTypes_MasterFrameOuts_MasterFrameOutId",
                table: "MasterFrameOutTypes",
                column: "MasterFrameOutId",
                principalTable: "MasterFrameOuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterFrameOutTypes_MasterFrameOuts_MasterFrameOutId",
                table: "MasterFrameOutTypes");

            migrationBuilder.AlterColumn<int>(
                name: "MasterFrameOutId",
                table: "MasterFrameOutTypes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterFrameOutTypes_MasterFrameOuts_MasterFrameOutId",
                table: "MasterFrameOutTypes",
                column: "MasterFrameOutId",
                principalTable: "MasterFrameOuts",
                principalColumn: "Id");
        }
    }
}
