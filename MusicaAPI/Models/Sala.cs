namespace MusicaAPI.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
        public List<Agendamento> Agendamentos { get; set;}
    }
}
