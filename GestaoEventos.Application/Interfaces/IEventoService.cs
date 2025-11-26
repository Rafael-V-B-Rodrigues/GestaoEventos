using GestaoEventos.Application.ViewModels;

namespace GestaoEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoViewModel> GetByIdAsync(int id);
        Task<IEnumerable<EventoViewModel>> GetAllAsync();
        Task<IEnumerable<EventoViewModel>> SearchAsync(string term);
        Task AddAsync(EventoViewModel eventoViewModel);
        Task UpdateAsync(EventoViewModel eventoViewModel);
        Task RemoveAsync(int id);
        
    }
}