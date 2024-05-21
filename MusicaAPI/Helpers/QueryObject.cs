namespace MusicaAPI.Helpers
{
    public class QueryObject
    {
        public string? Nome { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Telefone { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
