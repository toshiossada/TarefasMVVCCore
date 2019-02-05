using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarefas.Migrations {
    public partial class TarefasPopularDb : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("INSERT INTO tarefas(teste, DataConclusaoTarefa, EstaCompleta, Nome) Values(1, '20171010 08:00:00', 1, 'Tarefa 1')");
            migrationBuilder.Sql ("INSERT INTO tarefas(teste, DataConclusaoTarefa, EstaCompleta, Nome) Values(1, '20170909 08:00:00', 0, 'Tarefa 10')");
            migrationBuilder.Sql ("INSERT INTO tarefas(teste, DataConclusaoTarefa, EstaCompleta, Nome) Values(1, '20181010 08:00:00', 0, 'Tarefa 23')");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("DELETE tarefas;");
        }
    }
}