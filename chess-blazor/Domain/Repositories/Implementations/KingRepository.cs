using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Meeples;

namespace Domain.Repositories.Implementations; 

public class KingRepository : ARepository<King>, IRepository<King> {
    public KingRepository(ChessDbContext context) : base(context) {
    }
}