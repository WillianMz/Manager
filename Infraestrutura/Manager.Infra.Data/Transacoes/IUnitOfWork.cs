namespace Manager.Infra.Data.Transacoes
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
