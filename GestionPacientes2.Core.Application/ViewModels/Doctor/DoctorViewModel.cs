
using Microsoft.AspNetCore.Http;

namespace GestionPacientes2.Core.Application.ViewModels.Doctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int Identification { get; set; }

        public string Email { get; set; }

        public IFormFile Photo { get; set; }
        public string PhotoUrl { get; set; }
    }
}
