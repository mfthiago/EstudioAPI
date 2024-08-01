using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Estudios")]
    public class Estudio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int CheckIn { get; set; }
        public int CheckOut { get; set; }
        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Estudio() { }
    }
}
