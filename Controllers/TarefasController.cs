using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers {
    public class TarefasController : Controller {
        private readonly ITarefaItemService _tarefaItemService;
        public TarefasController (ITarefaItemService tarefaItemService) {
            _tarefaItemService = tarefaItemService;
        }
        public async Task<IActionResult> Index () {
            var tarefas = await _tarefaItemService.GetItensAsync ();
            var model = new TarefaViewModel () {
                tarefasItens = tarefas
            };
            return View (model);
        }

        [HttpGet]
        public IActionResult AcicionarItemTarefa () {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> AcicionarItemTarefa ([Bind ("id,EstaCompleta,Nome,DataConclusaoTarefa")] TarefaItem tarefa) {
            if (ModelState.IsValid) {
                await _tarefaItemService.AdicionarItemTarefa (tarefa);
                return RedirectToAction (nameof (Index));
            }

            return View (tarefa);
        }

        [HttpGet]
        public IActionResult Delete (int? id) {
            if (id == null) return NotFound ();

            var tarefaItem = _tarefaItemService.GetTarefaById (id ?? 0);

            if (tarefaItem == null) return NotFound ();

            return View (tarefaItem);
        }

        [HttpPost, ActionName ("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int? id) {
            await _tarefaItemService.DeletarItem (id ?? 0);
            return RedirectToAction (nameof (Index));
        }

        [HttpGet]
        public IActionResult Edit (int? id) {
            if (id == null) return NotFound ();

            var tarefaItem = _tarefaItemService.GetTarefaById (id ?? 0);

            if (tarefaItem == null) return NotFound ();

            return View (tarefaItem);
        }

        [HttpPost, ActionName ("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int? id, [Bind ("id,EstaCompleta,Nome,DataConclusaoTarefa")] TarefaItem tarefa) {

            if (id != tarefa.id) return NotFound ();
            if (ModelState.IsValid) {
                try {
                    await _tarefaItemService.Update (tarefa);
                } catch (DbUpdateConcurrencyException ex) {
                    throw ex;
                } catch (Exception e) {

                    throw e;
                }

                return RedirectToAction (nameof (Index));
            }
            return View (tarefa);

        }

    }
}