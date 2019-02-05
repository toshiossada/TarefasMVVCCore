using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarefas.Migrations
{
    public partial class Removerteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Tarefas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "teste",
                table: "Tarefas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
