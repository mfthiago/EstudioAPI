using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
