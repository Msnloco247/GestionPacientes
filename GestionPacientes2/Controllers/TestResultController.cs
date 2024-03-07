using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.TestResult;
using GestionPacientes2.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestionPacientes2.Controllers
{
    public class TestResultController : Controller
    {
        private readonly ITestResultService _testResultService;
        private readonly ValidateUserSession _validateUserSession;

        public TestResultController(ITestResultService testResultService, ValidateUserSession validateUserSession)
        {
            _testResultService = testResultService;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View(await _testResultService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            SaveTestResultViewModel vm = new();

            return View("SaveTestResult", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTestResultViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }


            await _testResultService.Add(vm);

            return RedirectToRoute(new { controller = "TestResult", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            SaveTestResultViewModel vm = await _testResultService.GetByIdSaveViewModel(id);
            return View("SaveTestResult", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTestResultViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            await _testResultService.GetByIdSaveViewModel(vm.Id);
            await _testResultService.Update(vm);
            return RedirectToRoute(new { controller = "TestResult", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(await _testResultService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            await _testResultService.Delete(id);


            return RedirectToRoute(new { controller = "TestResult", action = "Index" });
        }


    }
}
