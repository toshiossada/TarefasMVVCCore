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

        public async Task<bool> AdicionarItemTarefa (TarefaItem item) {
            var tarefa = new TarefaItem () {
                EstaCompleta = false,
                Nome = item.Nome,
                DataConclusaoTarefa = item.DataConclusaoTarefa
            };

            _context.Tarefas.Add (item);
            var result = await _context.SaveChangesAsync ();

            return result == 1;
        }

        public async Task<bool> DeletarItem (int id) {
            var tarefaItem = GetTarefaById (id);
            _context.Tarefas.Remove (tarefaItem);
            var result = await _context.SaveChangesAsync ();

            return result == 1;
        }

        public async Task<IEnumerable<TarefaItem>> GetItensAsync (bool? completa) {
            var result = await _context.Tarefas.Where (r => completa == null || r.EstaCompleta == completa).ToArrayAsync ();

            return result;
        }

        public TarefaItem GetTarefaById (int id) {
            var result = _context.Tarefas.Find (id);

            return result;
        }

        public async Task Update (TarefaItem item) {
            if (item == null) throw new ArgumentException (nameof (item));

            _context.Tarefas.Update (item);
            await _context.SaveChangesAsync ();
        }
    }
}