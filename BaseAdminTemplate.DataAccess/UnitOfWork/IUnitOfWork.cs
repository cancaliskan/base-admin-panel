using System;

using BaseAdminTemplate.DataAccess.Contracts;

namespace BaseAdminTemplate.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ILinkRolePermissionRepository LinkRolePermissionRepository { get; }
        ILinkUserRoleRepository LinkUserRoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IExceptionLogRepository ExceptionLogRepository { get; }
        ILinkMenuPermissionRepository LinkMenuPermissionRepository { get; }

        int Complete();
    }
}