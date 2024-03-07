using GestionPacientes2.Core.Application.ViewModels.User;
using GestionPacientes2.Core.Domain.Entities;

namespace GestionPacientes2.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel loginVm);
    }
}
