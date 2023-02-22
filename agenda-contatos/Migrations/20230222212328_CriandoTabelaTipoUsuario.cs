using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.Contatos.Migrations
{
    public partial class CriandoTabelaTipoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_TipoContatoModel_TipoId",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoContatoModel",
                table: "TipoContatoModel");

            migrationBuilder.RenameTable(
                name: "TipoContatoModel",
                newName: "TiposDeContato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposDeContato",
                table: "TiposDeContato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_TiposDeContato_TipoId",
                table: "Contatos",
                column: "TipoId",
                principalTable: "TiposDeContato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_TiposDeContato_TipoId",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposDeContato",
                table: "TiposDeContato");

            migrationBuilder.RenameTable(
                name: "TiposDeContato",
                newName: "TipoContatoModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoContatoModel",
                table: "TipoContatoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_TipoContatoModel_TipoId",
                table: "Contatos",
                column: "TipoId",
                principalTable: "TipoContatoModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
