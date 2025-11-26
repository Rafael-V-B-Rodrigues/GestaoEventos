using GestaoEventos.Application.Interfaces;
using GestaoEventos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace GestaoEventos.Web.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoService _eventoService;
        private readonly ICategoriaService _categoriaService; 
        public EventosController(IEventoService eventoService, ICategoriaService categoriaService)
        {
            _eventoService = eventoService;
            _categoriaService = categoriaService;
        }

        private async Task CarregarCategorias()
        {
            var categorias = await _categoriaService.GetAllAsync();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
        }

        // GET: /Eventos
        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoService.GetAllAsync();
            return View(eventos);
        }

        // GET: /Eventos/Create
        public async Task<IActionResult> Create()
        {
            await CarregarCategorias(); 
            return View();
        }

        // POST: /Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventoViewModel eventoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _eventoService.AddAsync(eventoViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            await CarregarCategorias();
            return View(eventoViewModel);
        }

        // GET: /Eventos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var evento = await _eventoService.GetByIdAsync(id);
            if (evento == null) return NotFound();

            await CarregarCategorias(); 
            return View(evento);
        }

        // POST: /Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventoViewModel eventoViewModel)
        {
            if (id != eventoViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _eventoService.UpdateAsync(eventoViewModel);
                return RedirectToAction(nameof(Index));
            }

            await CarregarCategorias();
            return View(eventoViewModel);
        }

        // GET: /Eventos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _eventoService.GetByIdAsync(id);
            if (evento == null) return NotFound();
            return View(evento);
        }

        // POST: /Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Action para busca via AJAX
        // URL esperada: /Eventos/Filter?termo=valor
        public async Task<IActionResult> Filter(string termo){
                IEnumerable<EventoViewModel> eventos;

                if (string.IsNullOrEmpty(termo))
                {
                    eventos = await _eventoService.GetAllAsync();
                }
                else
                {
                    eventos = await _eventoService.SearchAsync(termo);
                }
                return PartialView("_TabelaEventos", eventos);
        }
    }
}