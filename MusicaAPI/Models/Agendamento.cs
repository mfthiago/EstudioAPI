namespace MusicaAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Agendamento{ get; set; }
    }
}
