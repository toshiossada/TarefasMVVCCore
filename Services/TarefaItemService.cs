using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Services {
    public class TarefaItemService : ITarefaItemService {
        private readonly ApplicationDbContext _context;

        public TarefaItemService (ApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> AdicionarItemTarefa(TarefaItem item)
        {
            var tarefa = new TarefaItem(){
                EstaCompleta = false,
                Nome = item.Nome,
                DataConclusaoTarefa = item.DataConclusaoTarefa
            };

            _context.Tarefas.Add(item);
            var result = await _context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<IEnumerable<TarefaItem>> GetItensAsync () {
            var result = await _context.Tarefas.Where (r => !r.EstaCompleta).ToArrayAsync ();

            return result;
        }
    }
}