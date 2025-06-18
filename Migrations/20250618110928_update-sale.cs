using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supply.Migrations
{
    /// <inheritdoc />
    public partial class updatesale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_InvoiceItem_InvoiceItemId",
                table: "Sale");

            migrationBuilder.RenameColumn(
                name: "InvoiceItemId",
                table: "Sale",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_InvoiceItemId",
                table: "Sale",
                newName: "IX_Sale_InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Invoice_InvoiceId",
                table: "Sale",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Invoice_InvoiceId",
                table: "Sale");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Sale",
                newName: "InvoiceItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_InvoiceId",
                table: "Sale",
                newName: "IX_Sale_InvoiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_InvoiceItem_InvoiceItemId",
                table: "Sale",
                column: "InvoiceItemId",
                principalTable: "InvoiceItem",
                principalColumn: "InvoiceItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
