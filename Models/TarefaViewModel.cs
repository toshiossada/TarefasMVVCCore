using System.Collections.Generic;

namespace Tarefas.Models
{
    public class TarefaViewModel
    {
        public IEnumerable<TarefaItem> tarefasItens { get; set; }
    }
}