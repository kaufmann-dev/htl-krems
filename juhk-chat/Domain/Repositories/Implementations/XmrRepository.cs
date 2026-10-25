using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class XmrRepository : ARepository<XmrReceiveAddress>, IXmrRepository
{
    public XmrRepository(JUHKDbContext dbContext) : base(dbContext)
    {
    }
}