using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.Infra.Data.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAD_cargo",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAD_cargo", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "CAD_contato",
                columns: table => new
                {
                    con_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    con_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    con_telefone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    con_dtNasc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    con_sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    con_ativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAD_contato", x => x.con_id);
                    table.ForeignKey(
                        name: "FK_CAD_contato_CAD_cargo",
                        column: x => x.car_id,
                        principalTable: "CAD_cargo",
                        principalColumn: "car_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CAD_contato_car_id",
                table: "CAD_contato",
                column: "car_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAD_contato");

            migrationBuilder.DropTable(
                name: "CAD_cargo");
        }
    }
}
