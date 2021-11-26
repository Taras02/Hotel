using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class UP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OrderServices_OrderServiceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "OrderOrderService");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OrderServiceId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "OrderServiceId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_EmployeeId",
                table: "OrderServices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderServices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookingId",
                table: "Orders",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomID",
                table: "Bookings",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomID",
                table: "Bookings",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bookings_BookingId",
                table: "Orders",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Employees_EmployeeId",
                table: "OrderServices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
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
                name: "FK_Bookings_Rooms_RoomID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bookings_BookingId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Employees_EmployeeId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_EmployeeId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BookingId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderServices");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderServiceId",
                table: "Employees",
                type: "int",
                nullable: true);

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
                name: "IX_Rooms_BookingId",
                table: "Rooms",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OrderServiceId",
                table: "Employees",
                column: "OrderServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderService_OrdersOrderId",
                table: "OrderOrderService",
                column: "OrdersOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OrderServices_OrderServiceId",
                table: "Employees",
                column: "OrderServiceId",
                principalTable: "OrderServices",
                principalColumn: "OrderServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
