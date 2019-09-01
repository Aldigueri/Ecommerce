using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class iniciall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Compras",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ClienteCompras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteCompras_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClienteCompras_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClienteCompras_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCompras_CategoriaId",
                table: "ClienteCompras",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCompras_ProdutoId",
                table: "ClienteCompras",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCompras_UsuarioId",
                table: "ClienteCompras",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteCompras");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Compras");
        }
    }
}
