using MusicaAPI.Dtos.Equipamento;

namespace MusicaAPI.Dtos.Sala
{
    public class UpdateSalaRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
    }
}
