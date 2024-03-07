
using GestionPacientes2.Core.Application.Helpers;
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Application.ViewModels.User;
using GestionPacientes2.Core.Domain.Entities;
using GestionPacientes2.Infrastructure.Persitence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionPacientes2.Infrastructure.Persitence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }


        public override async Task<User> AddAsync(User user)
        {
            user.Password = PasswordEncryptation.ComputeSha256Hash(user.Password);
            await base.AddAsync(user);
            return user;
        }
        public override async Task<User> UpdateAsync(User user)
        {
            user.Password = PasswordEncryptation.ComputeSha256Hash(user.Password);
            await base.UpdateAsync(user);
            return user;
        }

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(loginVm.Password);

            User user = await _context.Set<User>().FirstOrDefaultAsync
                (user => user.UserName == loginVm.Username && user.Password == passwordEncrypt);
            return user;
        }

    }
}
