using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drone.Model.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estado__62EA894A6169A70C", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    idModelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modelo__13A52CD135EA748A", x => x.idModelo);
                });

            migrationBuilder.CreateTable(
                name: "Drone",
                columns: table => new
                {
                    idDrone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numerSerie = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    idModelo = table.Column<int>(type: "int", nullable: true),
                    pesoLimite = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    capacidadBateria = table.Column<int>(type: "int", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Drone__2CE1B38B031563CC", x => x.idDrone);
                    table.ForeignKey(
                        name: "FK__Drone__idEstado__619B8048",
                        column: x => x.idEstado,
                        principalTable: "Estado",
                        principalColumn: "idEstado");
                    table.ForeignKey(
                        name: "FK__Drone__idModelo__60A75C0F",
                        column: x => x.idModelo,
                        principalTable: "Modelo",
                        principalColumn: "idModelo");
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    idMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    peso = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    codigo = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IdDrone = table.Column<int>(type: "int", nullable: true),
                    IdDroneNavigationIdDrone = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medicame__42B24C58DDF7C54C", x => x.idMedicamento);
                    table.ForeignKey(
                        name: "FK_Medicamento_Drone_IdDroneNavigationIdDrone",
                        column: x => x.IdDroneNavigationIdDrone,
                        principalTable: "Drone",
                        principalColumn: "idDrone");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drone_idEstado",
                table: "Drone",
                column: "idEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Drone_idModelo",
                table: "Drone",
                column: "idModelo");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_IdDroneNavigationIdDrone",
                table: "Medicamento",
                column: "IdDroneNavigationIdDrone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Drone");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Modelo");
        }
    }
}
