
using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Domain.Entities;
using GestionPacientes2.Infrastructure.Persitence.Context;

namespace GestionPacientes2.Infrastructure.Persitence.Repository
{
    public class PacientDateRepository : GenericRepository<PacientDate>, IPacientDateRepository
    {
        private readonly ApplicationContext _context;

        public PacientDateRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
