using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class ChatRepository : ARepository<Chat>, IChatRepository
{
    public ChatRepository(JUHKDbContext dbContext) : base(dbContext)
    {
    }
}