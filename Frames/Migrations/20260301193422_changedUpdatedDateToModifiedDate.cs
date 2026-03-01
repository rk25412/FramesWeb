using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frames.Migrations
{
    /// <inheritdoc />
    public partial class changedUpdatedDateToModifiedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Workers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "WorkerFrameOutTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "WorkerFrameOuts",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "WorkerFrameIns",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Payments",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Paid",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MasterFrameOutTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MasterFrameOuts",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MasterFrameIns",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "FrameTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "BillingSummary",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "BillingItemDetail",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "BillingItem",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Billing",
                newName: "ModifiedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Workers",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "WorkerFrameOutTypes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "WorkerFrameOuts",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "WorkerFrameIns",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Payments",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Paid",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "MasterFrameOutTypes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "MasterFrameOuts",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "MasterFrameIns",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "FrameTypes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "BillingSummary",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "BillingItemDetail",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "BillingItem",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Billing",
                newName: "UpdatedDate");
        }
    }
}
