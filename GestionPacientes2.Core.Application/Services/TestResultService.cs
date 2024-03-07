using GestionPacientes2.Core.Application.Helpers;
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.TestResult;
using GestionPacientes2.Core.Application.ViewModels.User;
using GestionPacientes2.Core.Domain.Entities;
using GestionPacientes2.Core.Domain.Entities.joins;
using Microsoft.AspNetCore.Http;

namespace GestionPacientes2.Core.Application.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly ITestResultRepository _testResultRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;

        public TestResultService(ITestResultRepository testResultRepository, IHttpContextAccessor httpContextAccessor)
        {
            _testResultRepository = testResultRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task Update(SaveTestResultViewModel vm)
        {
            Pacient_TestResult testResult = await _testResultRepository.GetByIdAsync(vm.Id);
            testResult.TestResultId = vm.Id;
            testResult.TestResult.Report = vm.Report;
            testResult.TestResult.Status = vm.Status;
            testResult.Pacient.Name = vm.PacientName;
            testResult.Pacient.LastName = vm.PacientLastName;
            testResult.Pacient.Identification = int.Parse(vm.PacientIdentification);


            await _testResultRepository.UpdateAsync(testResult);
        }

        public async Task<SaveTestResultViewModel> Add(SaveTestResultViewModel vm)
        {
            Pacient_TestResult testResult = new();
            testResult.TestResultId = vm.Id;
            testResult.TestResult.Report = vm.Report;
            testResult.TestResult.Status = vm.Status;
            testResult.Pacient.Name = vm.PacientName;
            testResult.Pacient.LastName = vm.PacientLastName;
            testResult.Pacient.Identification = int.Parse(vm.PacientIdentification);


            testResult = await _testResultRepository.AddAsync(testResult);

            SaveTestResultViewModel testResultVm = new();

            testResultVm.Id = testResult.TestResultId;
            testResultVm.Report = testResult.TestResult.Report;
            testResultVm.Status = testResult.TestResult.Status;
            testResultVm.PacientName = testResult.Pacient.Name;
            testResultVm.PacientLastName = testResult.Pacient.LastName;
            testResultVm.PacientIdentification = testResult.Pacient.Identification.ToString();


            return testResultVm;
        }

        public async Task Delete(int id)
        {
            var testResult = await _testResultRepository.GetByIdAsync(id);
            await _testResultRepository.DeleteAsync(testResult);
        }

        public async Task<SaveTestResultViewModel> GetByIdSaveViewModel(int id)
        {
            var testResult = await _testResultRepository.GetByIdAsync(id);

            SaveTestResultViewModel testResultVm = new();
            testResultVm.Id = testResult.TestResultId;
            testResultVm.Report = testResult.TestResult.Report;
            testResultVm.Status = testResult.TestResult.Status;
            testResultVm.PacientName = testResult.Pacient.Name;
            testResultVm.PacientLastName = testResult.Pacient.LastName;
            testResultVm.PacientIdentification = testResult.Pacient.Identification.ToString();


            return testResultVm;
        }

        public async Task<List<TestResultViewModel>> GetAllViewModel()
        {
            var testResultList = await _testResultRepository.GetAllAsync();

            return testResultList.Select(testResult => new TestResultViewModel
            {
                Id = testResult.TestResultId,
                Status = testResult.TestResult.Status,
                Report = testResult.TestResult.Report,
                PacientName = testResult.Pacient.Name,
                PacientLastName = testResult.Pacient.LastName,
                PacientIdentification = testResult.Pacient.Identification.ToString()
            }).ToList();
        }
    }
}
