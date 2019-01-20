using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Repository.Brand;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.Base;
using FluentValidation;

namespace Demo.PatrimonyManagement.Service.Brand
{
    public class BrandService : BaseService<Domain.Brand>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository repository, IUnitOfWork unitOfWork, IValidator<Domain.Brand> validator)
            : base(repository, unitOfWork, validator)
        {
            _brandRepository = repository;
        }

        public override Result<Domain.Brand> Insert(Domain.Brand brand)
        {
            var result = CheckValidation(brand);
            if (result.Success)
                result.Value = _brandRepository.Insert(brand);
            return result;
        }

        public override Result<Domain.Brand> Update(Domain.Brand brand)
        {
            var result = CheckValidation(brand);
            if (result.Success)
                result.Value = _brandRepository.Update(brand);
            return result;
        }

        #region [ Private ]
        private Result<Domain.Brand> CheckValidation(Domain.Brand brand)
        {
            var result = Validate(brand);
            if (_brandRepository.Any(x => x.Name == brand.Name))
                result.Messages.Add("Já existe uma marca com esse nome.");

            return result;
        }
        #endregion
    }
}
