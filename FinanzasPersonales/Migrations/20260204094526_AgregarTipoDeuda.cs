using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanzasPersonales.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTipoDeuda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Deudas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_DeudaId",
                table: "Pagos",
                column: "DeudaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Deudas_DeudaId",
                table: "Pagos",
                column: "DeudaId",
                principalTable: "Deudas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Deudas_DeudaId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_DeudaId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Deudas");
        }
    }
}
