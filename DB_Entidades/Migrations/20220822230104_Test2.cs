using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Entidades.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlquiladosYVendidos_Clientes_ClientesId",
                table: "AlquiladosYVendidos");

            migrationBuilder.DropIndex(
                name: "IX_AlquiladosYVendidos_ClientesId",
                table: "AlquiladosYVendidos");

            migrationBuilder.DropColumn(
                name: "ClientesId",
                table: "AlquiladosYVendidos");

            migrationBuilder.DropColumn(
                name: "IdClienteFK",
                table: "AlquiladosYVendidos");

            migrationBuilder.DropColumn(
                name: "IdLibroFK",
                table: "AlquiladosYVendidos");

            migrationBuilder.CreateIndex(
                name: "IX_AlquiladosYVendidos_IdCliente",
                table: "AlquiladosYVendidos",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_AlquiladosYVendidos_Clientes_IdCliente",
                table: "AlquiladosYVendidos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlquiladosYVendidos_Clientes_IdCliente",
                table: "AlquiladosYVendidos");

            migrationBuilder.DropIndex(
                name: "IX_AlquiladosYVendidos_IdCliente",
                table: "AlquiladosYVendidos");

            migrationBuilder.AddColumn<int>(
                name: "ClientesId",
                table: "AlquiladosYVendidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdClienteFK",
                table: "AlquiladosYVendidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLibroFK",
                table: "AlquiladosYVendidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AlquiladosYVendidos_ClientesId",
                table: "AlquiladosYVendidos",
                column: "ClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlquiladosYVendidos_Clientes_ClientesId",
                table: "AlquiladosYVendidos",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
