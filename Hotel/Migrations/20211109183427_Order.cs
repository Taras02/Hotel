using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderServices");

            migrationBuilder.CreateTable(
                name: "OrderOrderService",
                columns: table => new
                {
                    OrderServicesOrderServiceId = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderService", x => new { x.OrderServicesOrderServiceId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_OrderOrderService_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderService_OrderServices_OrderServicesOrderServiceId",
                        column: x => x.OrderServicesOrderServiceId,
                        principalTable: "OrderServices",
                        principalColumn: "OrderServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderService_OrdersOrderId",
                table: "OrderOrderService",
                column: "OrdersOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOrderService");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderServices",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
