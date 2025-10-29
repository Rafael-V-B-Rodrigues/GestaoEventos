using GestaoEventos.Application.Interfaces;
using GestaoEventos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Web.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoService.GetAllAsync();
            return View(eventos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventoViewModel eventoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _eventoService.AddAsync(eventoViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(eventoViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var evento = await _eventoService.GetByIdAsync(id);
            if (evento == null) return NotFound();
            return View(evento);
        }

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
            return View(eventoViewModel);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _eventoService.GetByIdAsync(id);
            if (evento == null) return NotFound();
            return View(evento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}