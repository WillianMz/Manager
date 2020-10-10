using Manager.Domain.Interfaces;
using Manager.Infra.Data.Context;

namespace Manager.Infra.Data.Transacoes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManagerContext _manager;

        public UnitOfWork(ManagerContext manager)
        {
            _manager = manager;
        }

        public void SaveChanges()
        {
            _manager.SaveChanges();
        }
    }
}
