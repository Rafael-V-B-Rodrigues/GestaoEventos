using AutoMapper;
using GestaoEventos.Application.ViewModels;
using GestaoEventos.Core.Entities;

namespace GestaoEventos.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeia Entidade -> ViewModel
            CreateMap<Evento, EventoViewModel>().ReverseMap();
        }
    }
}