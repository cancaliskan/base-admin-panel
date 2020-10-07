using System.Collections.Generic;

using AutoMapper;

using BaseAdminTemplate.Domain.Entities;
using BaseAdminTemplate.Web.Models;

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
            CreateMap<IEnumerable<RoleViewModel>, List<Role>>();
            CreateMap<IEnumerable<Role>, List<RoleViewModel>>();

            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();
            CreateMap<IEnumerable<PermissionViewModel>, List<Permission>>();
            CreateMap<IEnumerable<Permission>, List<PermissionViewModel>>();
        }
    }
}