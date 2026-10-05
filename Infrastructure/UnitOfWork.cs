using Application.Interfaces;
using Infrastructure.Context;

namespace Infrastructure
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}
