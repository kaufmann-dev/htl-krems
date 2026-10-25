using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Meeples;

namespace Domain.Repositories.Implementations; 

public class BishopRepository : ARepository<Bishop>, IRepository<Bishop> {
    public BishopRepository(ChessDbContext context) : base(context) {
    }
}