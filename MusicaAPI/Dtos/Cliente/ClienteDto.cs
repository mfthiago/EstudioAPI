using MusicaAPI.Dtos.Agendamento;
using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Cliente
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        
        public List<AgendamentoDto> Agendas { get; set; } = new List<AgendamentoDto>();
    }
}
