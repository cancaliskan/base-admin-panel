using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Business.Helpers;
using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.UnitOfWork;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Services
{
    public sealed class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ResponseHelper<IQueryable<Permission>> _childListResponseHelper;
        private readonly ResponseHelper<IQueryable<Menu>> _listResponseHelper;

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _childListResponseHelper = new ResponseHelper<IQueryable<Permission>>();
            _listResponseHelper = new ResponseHelper<IQueryable<Menu>>();
        }

        public Response<IQueryable<Permission>> GetChildList(Guid parentId)
        {
            try
            {
                var childIdList = _unitOfWork.LinkMenuPermissionRepository
                                                          .GetByCondition(x => x.MenuId == parentId)
                                                          .Select(x => x.PermissionId);
                var childList = new List<Permission>();
                foreach (var id in childIdList)
                {
                    var child = _unitOfWork.PermissionRepository.GetByCondition(x => x.Id == id && x.DisplayInMenu).FirstOrDefault();
                    if (child != null)
                    {
                        childList.Add(child);
                    }
                }

                return _childListResponseHelper.SuccessResponse(childList.AsQueryable(), "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _childListResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Menu>> GetActiveMenus()
        {
            try
            {
                var menus = _unitOfWork.MenuRepository.GetActiveEntities();
                return _listResponseHelper.SuccessResponse(menus.AsQueryable(), "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }
    }
}