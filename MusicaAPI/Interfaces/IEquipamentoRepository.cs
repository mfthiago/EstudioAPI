using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Dtos.Equipamento;
using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IEquipamentoRepository
    {
        Task<List<Equipamento>> GetAllAsync();
        Task<Equipamento?> GetByIdAsync(int id);//FirstOrDefault podem ser nulos
        Task<Equipamento> CreateAsync(Equipamento equipamentoModel);
        Task<Equipamento?> UpdateAsync(int id, UpdateEquipamentoRequestDto equipamentoDto);
        Task<Equipamento?> DeleteAsync(int id);
    }
}
