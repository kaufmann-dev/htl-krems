using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Implementations; 

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {

    protected ChessDbContext _context;

    protected DbSet<TEntity> _table;

    public ARepository(ChessDbContext context) {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public async Task Create(TEntity entity) {
        _table.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TEntity entity) {
        _table.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity) {
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> Read(int id) => await _table.FindAsync(id);

    public async Task<List<TEntity>> Read(Expression<Func<TEntity, bool>> filter) =>
        await _table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAll(int start, int count) => await _table.Skip(start).Take(count).ToListAsync();
}