using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty ;
        public string Telefone { get; set; } = string.Empty;

        public List<Agenda> Agendas { get; set; } = new List<Agenda>();
        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Cliente(){ }

    }
}
