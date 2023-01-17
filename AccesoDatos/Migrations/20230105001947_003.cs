using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesoDatos.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "ViewFacturaProductos",
                newName: "NombreProducto");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "ViewFacturaProductos",
                newName: "DescripcionProducto");

            migrationBuilder.AddColumn<float>(
                name: "Descuento",
                table: "ViewFacturaProductos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IVA",
                table: "ViewFacturaProductos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "ViewFacturaProductos");

            migrationBuilder.DropColumn(
                name: "IVA",
                table: "ViewFacturaProductos");

            migrationBuilder.RenameColumn(
                name: "NombreProducto",
                table: "ViewFacturaProductos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "DescripcionProducto",
                table: "ViewFacturaProductos",
                newName: "Descripcion");
        }
    }
}
