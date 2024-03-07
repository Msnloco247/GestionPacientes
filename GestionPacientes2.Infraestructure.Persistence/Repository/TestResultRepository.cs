
using GestionPacientes2.Core.Application.Helpers;
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Domain.Entities;
using GestionPacientes2.Core.Domain.Entities.joins;
using GestionPacientes2.Infrastructure.Persitence.Context;

namespace GestionPacientes2.Infrastructure.Persitence.Repository
{
    public class TestResultRepository : GenericRepository<Pacient_TestResult>, ITestResultRepository
    {
        private readonly ApplicationContext _context;

        public TestResultRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }



    }
}
