using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Meeples;

namespace Domain.Repositories.Implementations; 

public class QueenRepository : ARepository<Queen>, IRepository<Queen> {
    public QueenRepository(ChessDbContext context) : base(context) {
    }
}