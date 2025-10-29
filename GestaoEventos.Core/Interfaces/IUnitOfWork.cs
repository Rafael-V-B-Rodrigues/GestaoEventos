namespace GestaoEventos.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventoRepository Eventos { get; }
        Task<int> CommitAsync(); 
    }
}