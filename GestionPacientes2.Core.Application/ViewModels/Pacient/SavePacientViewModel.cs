using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestionPacientes2.Core.Application.ViewModels.Pacient
{
    public class SavePacientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar su numero telefonico")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Debe colocar una identificacion valida")]
        [DataType(DataType.Text)]
        public string Identification { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar su direccion")]
        [DataType(DataType.Text)]
        public string Direction { get; set; }

        [Required(ErrorMessage = "Debe colocar su apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe decir si es fumador o no")]
        [DataType(DataType.Text)]
        public int Smooker { get; set; }


        [Required(ErrorMessage = "Debe decir si tiene alergias")]
        [DataType(DataType.Text)]
        public string Alergies { get; set; }

        [Required(ErrorMessage = "Debe especificar su fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }

        public string PhotoUrl { get; set; }
    }
}
