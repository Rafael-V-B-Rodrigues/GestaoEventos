using System.ComponentModel.DataAnnotations;

namespace GestaoEventos.Application.ViewModels
{
    public class EventoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O local é obrigatório")]
        public string Local { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória")]
        [DataType(DataType.DateTime)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A capacidade é obrigatória")]
        [Range(1, 100000, ErrorMessage = "A capacidade deve ser no mínimo 1")]
        public int Capacidade { get; set; }
    }
}