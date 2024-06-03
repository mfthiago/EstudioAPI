using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IAgendaRepository
    {
        Task<List<Agendamento>> GetUserAgenda(AppUser user);
    }
}
