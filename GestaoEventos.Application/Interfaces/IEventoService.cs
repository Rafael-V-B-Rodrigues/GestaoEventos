using GestaoEventos.Application.ViewModels;

namespace GestaoEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoViewModel> GetByIdAsync(int id);
        Task<IEnumerable<EventoViewModel>> GetAllAsync();
        Task AddAsync(EventoViewModel eventoViewModel);
        Task UpdateAsync(EventoViewModel eventoViewModel);
        Task RemoveAsync(int id);
    }
}