using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.Base;

namespace Demo.PatrimonyManagement.Service.User
{
    public interface IUserService : IBaseService<Domain.User>
    {
        Result<Domain.User> Authenticate(Domain.User user);
    }
}
