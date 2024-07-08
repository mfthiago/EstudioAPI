using Microsoft.AspNetCore.Identity;

namespace MusicaAPI.Models
{
    public class AppUser : IdentityUser
    {
        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
