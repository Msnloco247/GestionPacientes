
using GestionPacientes2.Core.Application.Interfaces.Services;
using GestionPacientes2.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionPacientes2.Infrastructure.Persitence
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITestResultService, TestResultService>();
            services.AddTransient<IPacientService, PacientService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<ILabTestService, LabTestService>();
            #endregion
        }


    }
}
