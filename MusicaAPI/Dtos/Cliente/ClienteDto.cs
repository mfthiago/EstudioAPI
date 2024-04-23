using MusicaAPI.Dtos.Agendamento;

namespace MusicaAPI.Dtos.Cliente
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        
        public List<AgendamentoDto> Agendamentos { get; set; }
    }
}
