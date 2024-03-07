
using GestionPacientes2.Core.Domain.Common;
using GestionPacientes2.Core.Domain.Entities.joins;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPacientes2.Core.Domain.Entities
{
    public class Pacient : AuditableBaseEntity
    {
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }

        public int Identification { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime BornDate { get; set; }

        public bool Smooker { get; set; }

        public string Alergies { get; set; }

        public string? Photo { get; set; }


        public ICollection<LabTest_Pacient>? LabTest_Pacients { get; set; }

    }
}
