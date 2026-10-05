namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChanges();
    }
}
