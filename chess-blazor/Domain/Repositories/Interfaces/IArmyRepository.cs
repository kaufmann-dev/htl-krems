using Model.Entities.Armies;

namespace Domain.Repositories.Interfaces; 

public interface IArmyRepository : IRepository<Army> {

    Task<Army?> ReadGraphAsync(int id);
}