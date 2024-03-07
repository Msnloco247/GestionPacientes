

using GestionPacientes2.Core.Application.Interfaces.Repositories;
using GestionPacientes2.Core.Domain.Entities;
using GestionPacientes2.Infrastructure.Persitence.Context;

namespace GestionPacientes2.Infrastructure.Persitence.Repository
{
    public class PacientRepository : GenericRepository<Pacient>, IPacientRepository
    {
        private readonly ApplicationContext _context;

        public PacientRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
