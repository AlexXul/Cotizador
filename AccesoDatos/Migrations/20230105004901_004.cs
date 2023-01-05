using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesoDatos.Migrations
{
    public partial class _004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubTotal",
                table: "ViewFacturaProductos",
                newName: "TotalPorProducto");

            migrationBuilder.AddColumn<float>(
                name: "PrecioProducto",
                table: "ViewFacturaProductos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioProducto",
                table: "ViewFacturaProductos");

            migrationBuilder.RenameColumn(
                name: "TotalPorProducto",
                table: "ViewFacturaProductos",
                newName: "SubTotal");
        }
    }
}
