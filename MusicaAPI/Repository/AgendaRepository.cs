using MusicaAPI.Data;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MusicaAPI.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly ApplicationDbContext _context;
        public AgendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Agenda>> GetUserAgenda(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
