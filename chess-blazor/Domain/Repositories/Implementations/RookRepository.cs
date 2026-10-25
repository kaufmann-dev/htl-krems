using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Meeples;

namespace Domain.Repositories.Implementations; 

public class RookRepository : ARepository<Rook>, IRepository<Rook> {
    public RookRepository(ChessDbContext context) : base(context) {
    }
}