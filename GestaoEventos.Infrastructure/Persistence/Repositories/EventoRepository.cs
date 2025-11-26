using GestaoEventos.Core.Entities;
using GestaoEventos.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoEventos.Infrastructure.Persistence.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            return await _context.Eventos
                .Include(e => e.Categoria) 
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventos
                .Include(e => e.Categoria) 
                .ToListAsync();
        }

        public async Task AddAsync(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
        }

        public void Update(Evento evento)
        {
            _context.Eventos.Update(evento);
        }

        public void Remove(Evento evento)
        {
            _context.Eventos.Remove(evento);
        }

        public async Task<IEnumerable<Evento>> SearchByNameAsync(string term)
        {
            return await _context.Eventos
                .Include(e => e.Categoria) 
                .Where(e => e.Nome.Contains(term))
                .ToListAsync();
        }
    }
}