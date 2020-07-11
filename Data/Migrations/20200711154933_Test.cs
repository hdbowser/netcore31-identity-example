using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi1.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CategoriaID",
                table: "AspNetUsers",
                column: "CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCategoria",
                table: "AspNetUsers",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCategoria",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CategoriaID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CategoriaID",
                table: "AspNetUsers");
        }
    }
}
