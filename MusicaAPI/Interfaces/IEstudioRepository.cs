using MusicaAPI.Dtos.Estudio;
using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IEstudioRepository
    {
        Task<List<Estudio>> GetAllAsync();
        Task<Estudio?> GetByIdAsync(int id);//FirstOrDefault podem ser nulos
        Task<Estudio> CreateAsync(Estudio estudioModel);
        Task<Estudio?> UpdateAsync(int id, UpdateEstudioRequestDto estudioDto);
        Task<Estudio?> DeleteAsync(int id);
        Task<bool> EstudioExists(int id);
    }
}
