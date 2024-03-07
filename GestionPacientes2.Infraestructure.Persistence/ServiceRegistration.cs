
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Infrastructure.Persitence.Context;
using GestionPacientes2.Infrastructure.Persitence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionPacientes2.Infrastructure.Persitence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        #region CONTEXT
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString, m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            }
            #endregion

            #region REPOSITORIES

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPacientRepository, PacientRepository>();
            services.AddTransient<ILabTestRepository, LabTestRepository>();
            services.AddTransient<ITestResultRepository, TestResultRepository>();
            services.AddTransient<IPacientDateRepository, PacientDateRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }

    }
}
