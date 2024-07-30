using MusicaAPI.Models;
using System.Threading.Tasks;

namespace MusicaAPI.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
        Task<bool> AgendamentoExists(int id, Agendamento agendamentoModel);
        Task<bool> AgendamentoExistsData(Agendamento agendamentoModel, int salaId);
        Task<Agendamento> CreateAsync(Agendamento agendamentoModel);

        Task<Agendamento?> UpdateAsync(int id, Agendamento agendamentoModel);

        Task<Agendamento?> DeleteAsync(int id);
        Task<List<Agendamento>> GetUserAgenda(AppUser user);

    }
}
