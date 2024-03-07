using GestionPacientes2.Core.Application.Helpers;
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.Doctor;
using GestionPacientes2.Core.Application.ViewModels.User;
using GestionPacientes2.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;


namespace GestionPacientes2.Core.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;

        public DoctorService(IDoctorRepository doctorRepository, IHttpContextAccessor httpContextAccessor)
        {
            _doctorRepository = doctorRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task Update(SaveDoctorViewModel vm)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(vm.Id);
            doctor.Id = vm.Id;
            doctor.Name = vm.Name;
            doctor.LastName = vm.LastName;
            doctor.Phone = vm.Phone;
            doctor.Email = vm.Email;
            doctor.Identification = int.Parse(vm.Identification);
            doctor.Photo = vm.PhotoUrl;


            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task<SaveDoctorViewModel> Add(SaveDoctorViewModel vm)
        {
            Doctor doctor = new();
            doctor.Id = vm.Id;
            doctor.Name = vm.Name;
            doctor.LastName = vm.LastName;
            doctor.Phone = vm.Phone;
            doctor.Email = vm.Email;
            doctor.Identification = int.Parse(vm.Identification);
            doctor.Photo = vm.PhotoUrl;

            doctor = await _doctorRepository.AddAsync(doctor);

            SaveDoctorViewModel doctorVm = new();

            doctorVm.Id = doctor.Id;
            doctorVm.Name = doctor.Name;
            doctorVm.Phone = doctor.Phone;
            doctorVm.Email = doctor.Email;
            doctorVm.LastName = doctor.LastName;
            doctorVm.Identification = doctor.Identification.ToString();
            doctorVm.PhotoUrl = doctor.Photo;

            return doctorVm;
        }

        public async Task Delete(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task<SaveDoctorViewModel> GetByIdSaveViewModel(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            SaveDoctorViewModel vm = new();
            vm.Id = doctor.Id;
            vm.Name = doctor.Name;
            vm.LastName = doctor.LastName;
            vm.Phone = doctor.Phone;
            vm.Email = doctor.Email;
            vm.Identification = doctor.Identification.ToString();
            vm.PhotoUrl = doctor.Photo;

            return vm;
        }

        public async Task<List<DoctorViewModel>> GetAllViewModel()
        {
            var doctorList = await _doctorRepository.GetAllAsync();

            return doctorList.Select(doctor => new DoctorViewModel
            {
                Name = doctor.Name,
                Phone = doctor.Phone,
                Id = doctor.Id,
                Email = doctor.Email,
                Identification = doctor.Identification,
                LastName = doctor.LastName,
                PhotoUrl = doctor.Photo
            }).ToList();
        }

    }
}
