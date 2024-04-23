using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
    }
}
