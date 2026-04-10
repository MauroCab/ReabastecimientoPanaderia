using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReabastecimientoPanaderia.DB.Migrations
{
    /// <inheritdoc />
    public partial class RenglonAndGeneralConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Renglones_Productos_ProductoSolicitadoID",
                table: "Renglones");

            migrationBuilder.DropIndex(
                name: "IX_Renglones_PedidoID",
                table: "Renglones");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipoProductoID",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoSolicitadoID",
                table: "Renglones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "Renglones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProducto_Codigo",
                table: "TiposProducto",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposProducto_Nombre",
                table: "TiposProducto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Renglones_PedidoID_ProductoSolicitadoID",
                table: "Renglones",
                columns: new[] { "PedidoID", "ProductoSolicitadoID" },
                unique: true,
                filter: "[ProductoSolicitadoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Nombre",
                table: "Productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoID_Nombre",
                table: "Productos",
                columns: new[] { "TipoProductoID", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FechaYHora",
                table: "Pedidos",
                column: "FechaYHora");

            migrationBuilder.AddForeignKey(
                name: "FK_Renglones_Productos_ProductoSolicitadoID",
                table: "Renglones",
                column: "ProductoSolicitadoID",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Renglones_Productos_ProductoSolicitadoID",
                table: "Renglones");

            migrationBuilder.DropIndex(
                name: "IX_TiposProducto_Codigo",
                table: "TiposProducto");

            migrationBuilder.DropIndex(
                name: "IX_TiposProducto_Nombre",
                table: "TiposProducto");

            migrationBuilder.DropIndex(
                name: "IX_Renglones_PedidoID_ProductoSolicitadoID",
                table: "Renglones");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Nombre",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipoProductoID_Nombre",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_FechaYHora",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "Renglones");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoSolicitadoID",
                table: "Renglones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Renglones_PedidoID",
                table: "Renglones",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoID",
                table: "Productos",
                column: "TipoProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Renglones_Productos_ProductoSolicitadoID",
                table: "Renglones",
                column: "ProductoSolicitadoID",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
