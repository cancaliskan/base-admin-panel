using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.DataAccess.Repositories;

namespace BaseAdminTemplate.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ILinkRolePermissionRepository LinkRolePermissionRepository { get; }
        public ILinkUserRoleRepository LinkUserRoleRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IExceptionLogRepository ExceptionLogRepository { get; }
        public ILinkMenuPermissionRepository LinkMenuPermissionRepository { get; }
        public IMenuRepository MenuRepository { get; }
        public IPasswordResetRepository PasswordResetRepository { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            LinkRolePermissionRepository = new LinkRolePermissionRepository(_applicationDbContext);
            LinkUserRoleRepository = new LinkUserRoleRepository(_applicationDbContext);
            UserRepository = new UserRepository(_applicationDbContext);
            RoleRepository = new RoleRepository(_applicationDbContext);
            PermissionRepository = new PermissionRepository(_applicationDbContext);
            ExceptionLogRepository = new ExceptionLogRepository(_applicationDbContext);
            LinkMenuPermissionRepository = new LinkMenuPermissionRepository(_applicationDbContext);
            MenuRepository = new MenuRepository(_applicationDbContext);
            PasswordResetRepository = new PasswordResetRepository(_applicationDbContext);
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