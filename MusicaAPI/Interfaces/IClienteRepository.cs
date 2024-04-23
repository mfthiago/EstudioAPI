using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync();
    }
}
