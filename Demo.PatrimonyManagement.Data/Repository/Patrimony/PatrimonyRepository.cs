using Demo.PatrimonyManagement.Data.Repository.Pattern;

namespace Demo.PatrimonyManagement.Data.Repository.Patrimony
{
    public class PatrimonyRepository : RepositoryPattern<Domain.Patrimony>, IPatrimonyRepository
    {
        public PatrimonyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
