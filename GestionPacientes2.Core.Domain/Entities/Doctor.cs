
using GestionPacientes2.Core.Domain.Common;
using GestionPacientes2.Core.Domain.Entities.joins;

namespace GestionPacientes2.Core.Domain.Entities
{
    public class Doctor : AuditableBaseEntity
    {

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public int Identification { get; set; }
        public string? Photo { get; set; }

        public ICollection<Doctor_Pacient>? Doctor_Pacients { get; set; }
    }
}
