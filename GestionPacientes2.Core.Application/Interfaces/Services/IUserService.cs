using GestionPacientes2.Core.Application.ViewModels.User;

namespace GestionPacientes2.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
    }
}
