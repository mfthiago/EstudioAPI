using Microsoft.AspNetCore.Identity;

namespace MusicaAPI.Models
{
    public class AppUser : IdentityUser
    {
        public List<Agenda> Agendas { get; set; } = new List<Agenda>();
    }
}
