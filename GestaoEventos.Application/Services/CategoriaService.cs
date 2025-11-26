using MapsterMapper;
using GestaoEventos.Application.Interfaces;
using GestaoEventos.Application.ViewModels;
using GestaoEventos.Core.Entities;
using GestaoEventos.Core.Interfaces;

namespace GestaoEventos.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaViewModel>> GetAllAsync()
        {
            var categorias = await _unitOfWork.Categorias.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);
        }

        public async Task<CategoriaViewModel> GetByIdAsync(int id)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            return _mapper.Map<CategoriaViewModel>(categoria);
        }

        public async Task AddAsync(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _unitOfWork.Categorias.AddAsync(categoria);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(CategoriaViewModel categoriaViewModel)
        {
            var categoriaExistente = await _unitOfWork.Categorias.GetByIdAsync(categoriaViewModel.Id);
            if (categoriaExistente == null) throw new Exception("Categoria não encontrada");
            categoriaExistente.Update(categoriaViewModel.Nome);

            _unitOfWork.Categorias.Update(categoriaExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (categoria == null) throw new Exception("Categoria não encontrada");
            _unitOfWork.Categorias.Remove(categoria);
            await _unitOfWork.CommitAsync();
        }
    }
}