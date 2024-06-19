using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Agenda

{
    public class CreateAgendaDto
    {

        [Required]
        [DataType(DataType.DateTime)]

        public DateTime DataInicial { get; set; }
        [Required]
        [DataType(DataType.DateTime)]

        public DateTime DataFinal { get; set; }
    }
}