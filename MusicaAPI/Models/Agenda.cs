using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        public string AppUserId { get; set; }
        public int AgendamentoId { get; set; }
        public string? AppUserName { get; set; }
        public AppUser AppUser { get; set; }
        public Agendamento Agendamento { get; set; }

        public Agenda()
        {
            
        }
    }
}
