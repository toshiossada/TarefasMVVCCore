using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers {
    public class TarefasController : Controller {
        private readonly ITarefaItemService _tarefaItemService;
        public TarefasController(ITarefaItemService tarefaItemService)
        {
            _tarefaItemService = tarefaItemService;
        }
        public async Task<IActionResult> Index() {
            var tarefas = await _tarefaItemService.GetItensAsync();
            var model = new TarefaViewModel(){
                 tarefasItens = tarefas
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AcicionarItemTarefa(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AcicionarItemTarefa([Bind("Id,EstaCompleta,Nome,DataConclusaoTarefa")]TarefaItem tarefa){
            if(ModelState.IsValid){
                await _tarefaItemService.AdicionarItemTarefa(tarefa);
                return RedirectToAction(nameof(Index));
            }
            
            return View(tarefa);
        }

    }
}