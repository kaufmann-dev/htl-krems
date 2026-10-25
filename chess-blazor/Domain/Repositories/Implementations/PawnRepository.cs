using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Meeples;

namespace Domain.Repositories.Implementations; 

public class PawnRepository : ARepository<Pawn>, IRepository<Pawn> {
    public PawnRepository(ChessDbContext context) : base(context) {
    }
}