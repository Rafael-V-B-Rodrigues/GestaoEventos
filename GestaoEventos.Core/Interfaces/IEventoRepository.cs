using GestaoEventos.Core.Entities;

namespace GestaoEventos.Core.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento> GetByIdAsync(int id);
        Task<IEnumerable<Evento>> GetAllAsync();
        Task AddAsync(Evento evento);
        void Update(Evento evento);
        void Remove(Evento evento);
    }
}