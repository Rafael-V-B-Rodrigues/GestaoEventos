namespace GestaoEventos.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventoRepository Eventos { get; }

        ICategoriaRepository Categorias {get; }
        Task<int> CommitAsync(); 
    }
}