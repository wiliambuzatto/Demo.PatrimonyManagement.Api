using System;

namespace Demo.PatrimonyManagement.Data.Infra
{
    public interface IUnitOfWork: IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
