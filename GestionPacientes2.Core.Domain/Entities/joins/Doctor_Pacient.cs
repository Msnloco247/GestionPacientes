namespace GestionPacientes2.Core.Domain.Entities.joins
{
    public class Doctor_Pacient
    {
        public int PacientId { get; set; }
        public Pacient Pacient { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
