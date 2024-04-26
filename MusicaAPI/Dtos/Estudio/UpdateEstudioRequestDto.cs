using MusicaAPI.Dtos.Sala;

namespace MusicaAPI.Dtos.Estudio
{
    public class UpdateEstudioRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public List<SalaDto> Salas { get; set; } = new List<SalaDto>();
    }
}
