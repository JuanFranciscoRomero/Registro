using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrodeEmpleado.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "beneficios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beneficios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechadeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechadeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeneficiosId = table.Column<int>(type: "int", nullable: false),
                    CargosId = table.Column<int>(type: "int", nullable: false),
                    HabilidadesId = table.Column<int>(type: "int", nullable: false),
                    ProyectosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empleados_beneficios_BeneficiosId",
                        column: x => x.BeneficiosId,
                        principalTable: "beneficios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleados_cargos_CargosId",
                        column: x => x.CargosId,
                        principalTable: "cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleados_habilidades_HabilidadesId",
                        column: x => x.HabilidadesId,
                        principalTable: "habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleados_proyectos_ProyectosId",
                        column: x => x.ProyectosId,
                        principalTable: "proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empleados_BeneficiosId",
                table: "empleados",
                column: "BeneficiosId");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_CargosId",
                table: "empleados",
                column: "CargosId");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_HabilidadesId",
                table: "empleados",
                column: "HabilidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_ProyectosId",
                table: "empleados",
                column: "ProyectosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "beneficios");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "habilidades");

            migrationBuilder.DropTable(
                name: "proyectos");
        }
    }
}
