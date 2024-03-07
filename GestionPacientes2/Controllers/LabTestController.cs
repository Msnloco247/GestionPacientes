using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.LabTest;
using GestionPacientes2.Middlewares;
using Microsoft.AspNetCore.Mvc;



namespace GestionPacientes2.Controllers
{
    public class LabTestController : Controller
    {
        private readonly ILabTestService _labTestService;
        private readonly ValidateUserSession _validateUserSession;

        public LabTestController(ILabTestService labTestService, ValidateUserSession validateUserSession)
        {
            _labTestService = labTestService;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View(await _labTestService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            SaveLabTestViewModel vm = new();

            return View("SaveLabTest", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveLabTestViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }


            await _labTestService.Add(vm);

            return RedirectToRoute(new { controller = "LabTest", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            SaveLabTestViewModel vm = await _labTestService.GetByIdSaveViewModel(id);
            return View("SaveLabTest", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveLabTestViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            await _labTestService.GetByIdSaveViewModel(vm.Id);
            await _labTestService.Update(vm);
            return RedirectToRoute(new { controller = "LabTest", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(await _labTestService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            await _labTestService.Delete(id);


            return RedirectToRoute(new { controller = "LabTest", action = "Index" });
        }


    }
}
