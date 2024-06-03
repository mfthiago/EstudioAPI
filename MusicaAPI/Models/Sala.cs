using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Salas")]
    public class Sala
    {
        public int Id { get; set; }
        public int? EstudioId { get; set; }
        public Estudio? Estudio { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
        public List<Agenda> Agendas { get; set; } = new List<Agenda>();

        public Sala() { }
    }
}
