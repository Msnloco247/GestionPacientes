
using GestionPacientes2.Core.Domain.Common;

namespace GestionPacientes2.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string UserName { get; set; }
        public int Access { get; set; }
    }
}
