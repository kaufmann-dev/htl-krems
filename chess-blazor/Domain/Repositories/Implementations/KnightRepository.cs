using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Meeples;

namespace Domain.Repositories.Implementations; 

public class KnightRepository : ARepository<Knight>, IRepository<Knight> {
    public KnightRepository(ChessDbContext context) : base(context) {
    }
}