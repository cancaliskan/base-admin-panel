using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.DataAccess.Repositories;

namespace BaseAdminTemplate.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            UserRepository = new UserRepository(_applicationDbContext);
            RoleRepository = new RoleRepository(_applicationDbContext);
            PermissionRepository = new PermissionRepository(_applicationDbContext);
        }

        public int Complete()
        {
            return _applicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationDbContext?.Dispose();
        }
    }
}