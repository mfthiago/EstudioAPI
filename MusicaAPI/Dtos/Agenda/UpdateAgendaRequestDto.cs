using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Agenda

{
    public class UpdateAgendaRequestDto
    {

        [Required]
        [DataType(DataType.DateTime)]

        public DateTime DataInicial { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataFinal { get; set; }
    }
}