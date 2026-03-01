using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frames.Migrations
{
    /// <inheritdoc />
    public partial class updatedPackages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BillingSummary_BillingId",
                table: "BillingSummary");

            migrationBuilder.CreateIndex(
                name: "IX_BillingSummary_BillingId",
                table: "BillingSummary",
                column: "BillingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BillingSummary_BillingId",
                table: "BillingSummary");

            migrationBuilder.CreateIndex(
                name: "IX_BillingSummary_BillingId",
                table: "BillingSummary",
                column: "BillingId");
        }
    }
}
