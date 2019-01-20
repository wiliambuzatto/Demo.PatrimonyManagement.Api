using Demo.PatrimonyManagement.Data.Repository.Pattern;

namespace Demo.PatrimonyManagement.Data.Repository.User
{
    public class UserRepository : RepositoryPattern<Domain.User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
