using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Dtos.Sala;
using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface ISalaRepository
    {
        Task<List<Sala>> GetAllAsync();
        Task<Sala?> GetByIdAsync(int id);//FirstOrDefault podem ser nulos
        Task<Sala> CreateAsync(Sala salaModel);
        Task<Sala?> UpdateAsync(int id, UpdateSalaRequestDto salaDto);
        Task<Sala?> DeleteAsync(int id);
        Task<bool> SalaExists(int id);
    }
}
