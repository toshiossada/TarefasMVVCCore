using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ITarefaItemService
    {
        Task<IEnumerable<TarefaItem>> GetItensAsync(bool? completa);
        Task<bool> AdicionarItemTarefa(TarefaItem item);
        Task<bool> DeletarItem(int id);
        TarefaItem GetTarefaById(int id);
        Task Update(TarefaItem item);

    }
}