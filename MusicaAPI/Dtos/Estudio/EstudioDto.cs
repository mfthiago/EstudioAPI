using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Dtos.Sala;

namespace MusicaAPI.Dtos.Estudio
{
    public class EstudioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int CheckIn { get; set; }
        public int CheckOut { get; set; }
        public List<SalaDto> Salas { get; set; } = new List<SalaDto>();
        public List<AgendamentoDto>? Agendamentos { get; set; }
    }
}
