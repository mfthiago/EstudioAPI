namespace MusicaAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty ;

        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Cliente(){ }

    }
}
