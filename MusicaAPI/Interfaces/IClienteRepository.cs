using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Helpers;
using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync(QueryObject query);
        Task<Cliente?> GetByIdAsync(int id);//FirstOrDefault podem ser nulos
        Task<Cliente> CreateAsync(Cliente clienteModel);
        Task<Cliente?> UpdateAsync(int id, UpdateClienteRequestDto clienteDto);
        Task<Cliente?> DeleteAsync(int id);
        Task<bool> ClienteExists(int id);

    }
}
