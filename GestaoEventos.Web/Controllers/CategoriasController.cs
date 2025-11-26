using GestaoEventos.Application.Interfaces;
using GestaoEventos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetAllAsync();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.AddAsync(categoriaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _categoriaService.UpdateAsync(categoriaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}