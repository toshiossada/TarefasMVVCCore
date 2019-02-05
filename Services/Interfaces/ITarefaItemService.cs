using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ITarefaItemService
    {
        Task<IEnumerable<TarefaItem>> GetItensAsync();
        Task<bool> AdicionarItemTarefa(TarefaItem item);
        


    }
}