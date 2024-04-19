namespace MusicaAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; } 
        public int EstudioId { get; set; }
        public Estudio? Estudio { get; set; }  
        public DateTime Data{ get; set; }

        public Agendamento() { }

    }
}
