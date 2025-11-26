using GestaoEventos.Application.ViewModels;

namespace GestaoEventos.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaViewModel> GetByIdAsync(int id);
        Task<IEnumerable<CategoriaViewModel>> GetAllAsync();
        Task AddAsync(CategoriaViewModel categoriaViewModel);
        Task UpdateAsync(CategoriaViewModel categoriaViewModel);
        Task RemoveAsync(int id);
    }
}