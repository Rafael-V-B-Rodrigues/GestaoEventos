using GestaoEventos.Core.Entities;

namespace GestaoEventos.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetByIdAsync(int id);
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task AddAsync(Categoria categoria);
        void Update(Categoria categoria);
        void Remove(Categoria categoria);
    }
}