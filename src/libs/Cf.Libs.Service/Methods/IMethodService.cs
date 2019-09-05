using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Method;

namespace Cf.Libs.Service.Methods
{
    public interface IMethodService : IBaseService
    {
        MethodDto Get(int Id);
        IPagedList<MethodDto> GetApplyMethod(int pageIndex, int pageSize);
        IPagedList<MethodDto> GetCleanMethod(int pageIndex, int pageSize);
        IPagedList<MethodDto> GetSoftMethod(int pageIndex, int pageSize);
        IPagedList<MethodDto> GetDryMethod(int pageIndex, int pageSize);
        IPagedList<MethodDto> GetStraightMethod(int pageIndex, int pageSize);
        IPagedList<MethodDto> GetDeliveryMethod(int pageIndex, int pageSize);
        IPagedList<MethodDto> GetAll(int pageIndex, int pageSize);
        MethodDto Add(MethodRequest request);
        MethodDto Edit(MethodRequest request);
        bool Delete(int id);
    }
}