
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.Doctor;
using GestionPacientes2.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace gestor_de_pacientes.Controllers
{
    public class DoctorController : Controller
    {

        private readonly IDoctorService _doctorService;
        private readonly ValidateUserSession _validateUserSession;

        public DoctorController(IDoctorService doctorService, ValidateUserSession validateUserSession)
        {
            _doctorService = doctorService;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _doctorService.GetAllViewModel());
        }

        public async Task<IActionResult> Prueba()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _doctorService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            SaveDoctorViewModel vm = new();

            return View("SaveDoctor", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveDoctorViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            SaveDoctorViewModel doctorVm = await _doctorService.Add(vm);

            if (doctorVm.Id != 0 && doctorVm != null)
            {
                SaveFiles save = new();
                doctorVm.PhotoUrl = save.UploadFile(vm.File, doctorVm.Id);

                await _doctorService.Update(doctorVm);
            }

            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            SaveDoctorViewModel vm = await _doctorService.GetByIdSaveViewModel(id);
            await _doctorService.GetAllViewModel();
            return View("SaveDoctor", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveDoctorViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveFiles save = new();


            SaveDoctorViewModel doctorVm = await _doctorService.GetByIdSaveViewModel(vm.Id);
            vm.PhotoUrl = save.UploadFile(vm.File, vm.Id, true, doctorVm.PhotoUrl);
            await _doctorService.Update(vm);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(await _doctorService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _doctorService.Delete(id);

            string basePath = $"/images/Doctors/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directory.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }

            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }


    }
}
