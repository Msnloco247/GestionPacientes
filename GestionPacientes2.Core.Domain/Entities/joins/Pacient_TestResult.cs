
namespace GestionPacientes2.Core.Domain.Entities.joins
{
    public class Pacient_TestResult
    {
        public int PacientId { get; set; }
        public Pacient Pacient { get; set; }

        public int TestResultId { get; set; }

        public TestResult TestResult { get; set; }
    }
}
