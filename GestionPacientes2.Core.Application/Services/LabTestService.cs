using GestionPacientes2.Core.Application.Helpers;
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.LabTest;
using GestionPacientes2.Core.Application.ViewModels.User;
using GestionPacientes2.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GestionPacientes2.Core.Application.Services
{
    public class LabTestService : ILabTestService
    {
        private readonly ILabTestRepository _labTestRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;

        public LabTestService(ILabTestRepository labTestRepository, IHttpContextAccessor httpContextAccessor)
        {
            _labTestRepository = labTestRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task Update(SaveLabTestViewModel vm)
        {
            LabTest labTest = await _labTestRepository.GetByIdAsync(vm.Id);
            labTest.Id = vm.Id;
            labTest.Name = vm.Name;

            await _labTestRepository.UpdateAsync(labTest);
        }

        public async Task<SaveLabTestViewModel> Add(SaveLabTestViewModel vm)
        {
            LabTest labTest = new();
            labTest.Name = vm.Name;

            labTest = await _labTestRepository.AddAsync(labTest);

            SaveLabTestViewModel labTestVm = new();

            labTestVm.Id = labTest.Id;
            labTestVm.Name = labTest.Name;

            return labTestVm;
        }

        public async Task Delete(int id)
        {
            var labTest = await _labTestRepository.GetByIdAsync(id);
            await _labTestRepository.DeleteAsync(labTest);
        }

        public async Task<SaveLabTestViewModel> GetByIdSaveViewModel(int id)
        {
            var labTest = await _labTestRepository.GetByIdAsync(id);

            SaveLabTestViewModel vm = new();
            vm.Id = labTest.Id;
            vm.Name = labTest.Name;


            return vm;
        }

        public async Task<List<LabTestViewModel>> GetAllViewModel()
        {
            var labTestList = await _labTestRepository.GetAllAsync();

            return labTestList.Select(labTest => new LabTestViewModel
            {
                Id = labTest.Id,
                Name = labTest.Name,

            }).ToList();
        }
    }
}
