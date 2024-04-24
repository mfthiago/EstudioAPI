namespace MusicaAPI.Dtos.Equipamento
{
    public class EquipamentoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Instrumento { get; set; } = string.Empty;
        public int? SalaId { get; set; }
    }
}
