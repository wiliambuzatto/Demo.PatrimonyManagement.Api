using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.Base;
using System;

namespace Demo.PatrimonyManagement.Service.Patrimony
{
    public interface IPatrimonyService : IBaseService<Domain.Patrimony>
    {
        PagedList<Domain.Patrimony> GetPatrimoniesByBrandId(Guid id, int page, int itemsPerPage); 
    }
}

