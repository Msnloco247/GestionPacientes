namespace GestionPacientes2.Core.Domain.Entities.joins
{
    public class Doctor_PacientDate
    {
        public int PacientDateId { get; set; }
        public PacientDate PacientDate { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
