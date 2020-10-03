using System;

namespace BaseAdminTemplate.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}