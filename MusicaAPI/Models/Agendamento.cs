using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Agendamentos")]
    public class Agendamento
    {
        public int Id { get; set; }
        public int? EstudioId { get; set; }
        public string? EstudioNome { get; set; }
        public string? AppUserName { get; set; }
        public Estudio? Estudio { get; set; }
        public double Preco{ get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public Agendamento() { }

    }
}
