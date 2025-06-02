using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supply.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerId",
                table: "Sale",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_EmployeeId",
                table: "Sale",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_InvoiceItemId",
                table: "Sale",
                column: "InvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_ProductId",
                table: "InvoiceItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Customer_CustomerId",
                table: "Sale",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Employee_EmployeeId",
                table: "Sale",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_InvoiceItem_InvoiceItemId",
                table: "Sale",
                column: "InvoiceItemId",
                principalTable: "InvoiceItem",
                principalColumn: "InvoiceItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Customer_CustomerId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Employee_EmployeeId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_InvoiceItem_InvoiceItemId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_CustomerId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_EmployeeId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_InvoiceItemId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItem_ProductId",
                table: "InvoiceItem");
        }
    }
}
