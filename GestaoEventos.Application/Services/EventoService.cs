using AutoMapper;
using GestaoEventos.Application.Interfaces;
using GestaoEventos.Application.ViewModels;
using GestaoEventos.Core.Entities;
using GestaoEventos.Core.Interfaces;

namespace GestaoEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventoViewModel>> GetAllAsync()
        {
            var eventos = await _unitOfWork.Eventos.GetAllAsync();
            return _mapper.Map<IEnumerable<EventoViewModel>>(eventos);
        }

        public async Task<EventoViewModel> GetByIdAsync(int id)
        {
            var evento = await _unitOfWork.Eventos.GetByIdAsync(id);
            return _mapper.Map<EventoViewModel>(evento);
        }

        public async Task AddAsync(EventoViewModel eventoViewModel)
        {
            var evento = _mapper.Map<Evento>(eventoViewModel);

            await _unitOfWork.Eventos.AddAsync(evento);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(EventoViewModel eventoViewModel)
        {
            var eventoExistente = await _unitOfWork.Eventos.GetByIdAsync(eventoViewModel.Id);
            if (eventoExistente == null)
                throw new Exception("Evento não encontrado");

            eventoExistente.Update(
                eventoViewModel.Nome,
                eventoViewModel.Descricao,
                eventoViewModel.Local,
                eventoViewModel.DataInicio,
                eventoViewModel.Capacidade
            );

            _unitOfWork.Eventos.Update(eventoExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var evento = await _unitOfWork.Eventos.GetByIdAsync(id);
            if (evento == null)
                throw new Exception("Evento não encontrado");

            _unitOfWork.Eventos.Remove(evento);
            await _unitOfWork.CommitAsync();
        }
    }
}