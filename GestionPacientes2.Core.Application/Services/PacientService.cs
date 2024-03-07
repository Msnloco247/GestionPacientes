using GestionPacientes2.Core.Application.Helpers;
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.Pacient;
using GestionPacientes2.Core.Application.ViewModels.User;
using GestionPacientes2.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;


namespace GestionPacientes2.Core.Application.Services
{
    public class PacientService : IPacientService
    {
        private readonly IPacientRepository _pacientRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;

        public PacientService(IPacientRepository pacientRepository, IHttpContextAccessor httpContextAccessor)
        {
            _pacientRepository = pacientRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task Update(SavePacientViewModel vm)
        {
            Pacient pacient = await _pacientRepository.GetByIdAsync(vm.Id);
            pacient.Id = vm.Id;
            pacient.Name = vm.Name;
            pacient.LastName = vm.LastName;
            pacient.Phone = vm.Phone;
            pacient.Identification = int.Parse(vm.Identification);
            pacient.Photo = vm.PhotoUrl;
            pacient.Alergies = vm.Alergies;
            pacient.Smooker = vm.Smooker == 1 ? true : false;
            pacient.BornDate = vm.BornDate;
            pacient.Direction = vm.Direction;

            await _pacientRepository.UpdateAsync(pacient);
        }

        public async Task<SavePacientViewModel> Add(SavePacientViewModel vm)
        {
            Pacient pacient = new();
            pacient.Id = vm.Id;
            pacient.Name = vm.Name;
            pacient.LastName = vm.LastName;
            pacient.Phone = vm.Phone;
            pacient.Identification = int.Parse(vm.Identification);
            pacient.Photo = vm.PhotoUrl;
            pacient.Alergies = vm.Alergies;
            pacient.Smooker = vm.Smooker == 1 ? true : false;
            pacient.BornDate = vm.BornDate;
            pacient.Direction = vm.Direction;


            pacient = await _pacientRepository.AddAsync(pacient);

            SavePacientViewModel pacientVm = new();

            pacientVm.Id = pacient.Id;
            pacientVm.Name = pacient.Name;
            pacientVm.LastName = pacient.LastName;
            pacientVm.Phone = pacient.Phone;
            pacientVm.Alergies = pacient.Alergies;
            pacientVm.Identification = pacient.Identification.ToString();
            pacientVm.PhotoUrl = pacient.Photo;
            pacientVm.Smooker = pacient.Smooker == true ? 1 : 2;
            pacientVm.BornDate = pacient.BornDate;
            pacientVm.Direction = pacient.Direction;


            return pacientVm;
        }

        public async Task Delete(int id)
        {
            var pacient = await _pacientRepository.GetByIdAsync(id);
            await _pacientRepository.DeleteAsync(pacient);
        }

        public async Task<SavePacientViewModel> GetByIdSaveViewModel(int id)
        {
            var pacient = await _pacientRepository.GetByIdAsync(id);

            SavePacientViewModel vm = new();
            vm.Id = pacient.Id;
            vm.Name = pacient.Name;
            vm.LastName = pacient.LastName;
            vm.Phone = pacient.Phone;
            vm.Identification = pacient.Identification.ToString();
            vm.Alergies = pacient.Alergies;
            vm.PhotoUrl = pacient.Photo;
            vm.Smooker = pacient.Smooker == true ? 1 : 2;
            vm.BornDate = pacient.BornDate;
            vm.Direction = pacient.Direction;


            return vm;
        }

        public async Task<List<PacientViewModel>> GetAllViewModel()
        {
            var pacientList = await _pacientRepository.GetAllAsync();

            return pacientList.Select(pacient => new PacientViewModel
            {
                Id = pacient.Id,
                Name = pacient.Name,
                LastName = pacient.LastName,
                Phone = pacient.Phone,
                Identification = pacient.Identification.ToString(),
                Alergies = pacient.Alergies,
                PhotoUrl = pacient.Photo,
                Smooker = pacient.Smooker == true ? 1 : 2,
                BornDate = pacient.BornDate,
                Direction = pacient.Direction
            }).ToList();
        }

    }
}
