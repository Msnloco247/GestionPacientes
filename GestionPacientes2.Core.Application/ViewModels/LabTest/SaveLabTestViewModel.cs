
using System.ComponentModel.DataAnnotations;

namespace GestionPacientes2.Core.Application.ViewModels.LabTest
{
    public class SaveLabTestViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

    }
}
