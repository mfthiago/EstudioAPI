using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
        Task<bool> AgendamentoExists(int id);
        Task<Agendamento> CreateAsync(Agendamento agendamentoModel);

    }
}
