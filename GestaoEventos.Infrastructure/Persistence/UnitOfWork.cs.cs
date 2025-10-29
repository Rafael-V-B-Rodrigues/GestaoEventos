using GestaoEventos.Core.Interfaces;
using GestaoEventos.Infrastructure.Persistence.Repositories;

namespace GestaoEventos.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IEventoRepository Eventos { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Eventos = new EventoRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}