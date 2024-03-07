namespace GestionPacientes2.Core.Domain.Entities.joins
{
    public class LabTest_Pacient
    {
        public int PacientId { get; set; }

        public Pacient Pacient { get; set; }

        public int LabTestId { get; set; }

        public LabTest LabTest { get; set; }
    }
}
