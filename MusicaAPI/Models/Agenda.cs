using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        public string AppUserId { get; set; }
        public int ClienteId { get; set; }
        public int SalaId { get; set; }
        public int AgendamentoId { get; set; }
        public AppUser AppUser { get; set; }
        public Cliente Cliente { get; set; }
        public Sala Sala { get; set; }
        public Agendamento Agendamento { get; set; }
    }
}
