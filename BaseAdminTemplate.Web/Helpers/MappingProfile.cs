using AutoMapper;

using BaseAdminTemplate.Domain.Entities;
using BaseAdminTemplate.Web.Models.ViewModels;

namespace BaseAdminTemplate.Web.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuViewModel>();
            CreateMap<MenuViewModel, Menu>();

            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();

            CreateMap<ExceptionLog, ExceptionLogViewModel>();
            CreateMap<ExceptionLogViewModel, ExceptionLog>();
        }
    }
}