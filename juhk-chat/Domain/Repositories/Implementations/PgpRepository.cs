using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class PgpRepository : ARepository<PgpPublicKey>, IPgpRepository
{
    public PgpRepository(JUHKDbContext dbContext) : base(dbContext)
    {
    }
}