using Microsoft.AspNetCore.Http;

namespace GestionPacientes2.Core.Application.ViewModels.Pacient
{
    public class PacientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
        public string Phone { get; set; }


        public string Direction { get; set; }

        public string Identification { get; set; }

        public int Smooker { get; set; }

        public string Alergies { get; set; }

        public DateTime BornDate { get; set; }

        public IFormFile Photo { get; set; }
        public string PhotoUrl { get; set; }
    }

}
