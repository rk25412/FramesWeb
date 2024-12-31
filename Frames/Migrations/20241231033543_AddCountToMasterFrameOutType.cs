using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frames.Migrations
{
    /// <inheritdoc />
    public partial class AddCountToMasterFrameOutType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "MasterFrameOutTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "MasterFrameOutTypes");
        }
    }
}
