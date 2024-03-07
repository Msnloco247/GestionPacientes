
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.Pacient;
using GestionPacientes2.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestionPacientes2.Controllers
{
    public class PacientController : Controller
    {

        private readonly IPacientService _pacientService;
        private readonly ValidateUserSession _validateUserSession;

        public PacientController(IPacientService pacientService, ValidateUserSession validateUserSession)
        {
            _pacientService = pacientService;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }


            return View(await _pacientService.GetAllViewModel());
        }



        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            SavePacientViewModel vm = new();

            return View("SavePacient", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePacientViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }


            SavePacientViewModel pacientVm = await _pacientService.Add(vm);

            if (pacientVm.Id != 0 && pacientVm != null)
            {
                SaveFiles save = new();
                pacientVm.PhotoUrl = save.UploadFile(vm.File, pacientVm.Id);

                await _pacientService.Update(pacientVm);
            }

            return RedirectToRoute(new { controller = "Pacient", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            SavePacientViewModel vm = await _pacientService.GetByIdSaveViewModel(id);
            return View("SavePacient", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePacientViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }



            SavePacientViewModel pacientVm = await _pacientService.GetByIdSaveViewModel(vm.Id);
            SaveFiles save = new();

            vm.PhotoUrl = save.UploadFile(vm.File, vm.Id, true, pacientVm.PhotoUrl);
            await _pacientService.Update(vm);
            return RedirectToRoute(new { controller = "Pacient", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(await _pacientService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _pacientService.Delete(id);

            string basePath = $"/images/Pacients/{id}";
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

            return RedirectToRoute(new { controller = "Pacient", action = "Index" });
        }


    }
}
