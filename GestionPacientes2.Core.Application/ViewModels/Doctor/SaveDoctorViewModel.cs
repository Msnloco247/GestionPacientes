
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestionPacientes2.Core.Application.ViewModels.Doctor
{
    public class SaveDoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar su numero telefonico")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Debe colocar una identificacion valida")]
        [DataType(DataType.Text)]
        public string Identification { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar un correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar su apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

    }
}
