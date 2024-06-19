using MusicaAPI.Models;
using System.Runtime.CompilerServices;

namespace MusicaAPI.Interfaces
{
    public interface IAgendaRepository
    {
        Task<List<Agenda>> GetUserAgenda(AppUser user);

    }
}
