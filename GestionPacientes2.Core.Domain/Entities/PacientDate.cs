
using GestionPacientes2.Core.Domain.Entities.joins;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPacientes2.Core.Domain.Entities
{
    public class PacientDate
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateDay { get; set; }

        public string Hour { get; set; }

        public int Status { get; set; }

        public string Reason { get; set; }

        public Doctor_PacientDate? Doctor_PacientDate { get; set; }

    }
}
