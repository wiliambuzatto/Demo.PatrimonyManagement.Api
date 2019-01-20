using Demo.PatrimonyManagement.Data.Repository.Pattern;

namespace Demo.PatrimonyManagement.Data.Repository.Brand
{
    public class BrandRepository : RepositoryPattern<Domain.Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
