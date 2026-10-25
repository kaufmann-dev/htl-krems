using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities.Armies;

namespace Domain.Repositories.Implementations; 

public class ArmyRepository : ARepository<Army>, IArmyRepository {
    public ArmyRepository(ChessDbContext context) : base(context) {
    }

    public async Task<Army?> ReadGraphAsync(int id) => await _table
        .Include(a => a.Meeples)
        .SingleOrDefaultAsync(a => a.Id == id);
}