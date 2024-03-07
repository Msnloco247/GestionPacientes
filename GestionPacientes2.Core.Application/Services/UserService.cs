

using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.ViewModels.User;
using GestionPacientes2.Core.Domain.Entities;

namespace GestionPacientes2.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Login(LoginViewModel loginvm)
        {
            UserViewModel vm = new UserViewModel();

            User user = await _userRepository.LoginAsync(loginvm);

            if (user == null)
            {
                return null;
            }

            vm.Id = user.Id;
            vm.UserName = user.UserName;
            vm.Password = user.Password;
            vm.Email = user.Email;
            vm.Name = user.Name;
            vm.Access = user.Access;
            vm.LastName = user.LastName;

            return vm;
        }

        public async Task Update(SaveUserViewModel vm)
        {

            User user = await _userRepository.GetByIdAsync(vm.Id);
            user.Id = vm.Id;
            user.Name = vm.Name;
            user.UserName = vm.Username;
            user.Password = vm.Password;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.Access = int.Parse(vm.Access);

            await _userRepository.UpdateAsync(user);
        }

        public async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            User user = new();
            user.Id = vm.Id;
            user.Name = vm.Name;
            user.UserName = vm.Username;
            user.Password = vm.Password;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.Access = int.Parse(vm.Access);


            user = await _userRepository.AddAsync(user);

            SaveUserViewModel userVm = new();

            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.LastName = user.LastName;
            userVm.Email = user.Email;
            userVm.Username = user.UserName;
            userVm.Password = user.Password;
            user.Access = user.Access;

            return userVm;
        }

        public async Task Delete(int id)
        {
            var product = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(product);
        }

        public async Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            SaveUserViewModel userVm = new();
            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.LastName = user.LastName;
            userVm.Email = user.Email;
            userVm.Username = user.UserName;
            userVm.Password = user.Password;
            userVm.Access = user.Access.ToString();

            return userVm;
        }

        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var userList = await _userRepository.GetAllAsync();

            return userList.Select(user => new UserViewModel
            {
                Name = user.Name,
                UserName = user.UserName,
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                LastName = user.LastName,
                Access = user.Access
            }).ToList();
        }
    }
}
