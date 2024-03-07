
using GestionPacientes2.Core.Domain.Entities.joins;

namespace GestionPacientes2.Core.Domain.Entities
{
    public class TestResult
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string? Report { get; set; }

        public Pacient_TestResult? Pacient_TestResult { get; set; }
    }
}
