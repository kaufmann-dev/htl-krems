using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Meeples;

namespace Domain.Repositories.Implementations; 

public class MeepleRepository : ARepository<AMeeple>, IRepository<AMeeple> {
    
    public MeepleRepository(ChessDbContext context) : base(context) {
    }
}