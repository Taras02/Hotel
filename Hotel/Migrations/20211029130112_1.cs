using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_orderServices_OrderServiceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_orderServices_Orders_OrderId",
                table: "orderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderServices",
                table: "orderServices");

            migrationBuilder.RenameTable(
                name: "orderServices",
                newName: "OrderServices");

            migrationBuilder.RenameIndex(
                name: "IX_orderServices_OrderId",
                table: "OrderServices",
                newName: "IX_OrderServices_OrderId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices",
                column: "OrderServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OrderServices_OrderServiceId",
                table: "Employees",
                column: "OrderServiceId",
                principalTable: "OrderServices",
                principalColumn: "OrderServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OrderServices_OrderServiceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices");

            migrationBuilder.RenameTable(
                name: "OrderServices",
                newName: "orderServices");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_OrderId",
                table: "orderServices",
                newName: "IX_orderServices_OrderId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderServices",
                table: "orderServices",
                column: "OrderServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_orderServices_OrderServiceId",
                table: "Employees",
                column: "OrderServiceId",
                principalTable: "orderServices",
                principalColumn: "OrderServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderServices_Orders_OrderId",
                table: "orderServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
