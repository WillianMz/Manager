namespace Manager.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
