using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Repository;
using Demo.PatrimonyManagement.Data.Repository.Pattern;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.Base;
using FluentValidation;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.PatrimonyManagement.Service.Patrimony
{
    public class PatrimonyService : BaseService<Domain.Patrimony>, IPatrimonyService
    {
        private readonly IPatrimonyRepository _patrimonyRepository;
        public PatrimonyService(IPatrimonyRepository repository, IUnitOfWork unitOfWork, IValidator<Domain.Patrimony> validator)
            : base(repository, unitOfWork, validator)
        {
            _patrimonyRepository = repository;
        }

        public PagedList<Domain.Patrimony> GetPatrimoniesByBrandId(Guid id, int page, int itemsPerPage)
          => Search(x => x.BrandId.Equals(id), page, itemsPerPage);


        public override Result<Domain.Patrimony> Insert(Domain.Patrimony patrimony)
        {
            patrimony.TippingNumber = Guid.NewGuid();
            var result = Validate(patrimony);
            if (result.Success)
                result.Value = _patrimonyRepository.Insert(patrimony);
            return result;
        }

        #region [ Private ]

        private PagedList<Domain.Patrimony> Search(Expression<Func<Domain.Patrimony, bool>> filter, int page, int itemsPerPage)
        {
            var result = _patrimonyRepository.Get()
                .Where(filter)
                .Select(p => new Domain.Patrimony
                {
                    Id = p.Id,
                    CreationDate = p.CreationDate,
                    Description = p.Description,
                    Name = p.Name,
                    TippingNumber = p.TippingNumber,
                    BrandId = p.BrandId,
                    Brand = new Domain.Brand()
                    {
                        Id = p.Brand.Id,
                        CreationDate = p.Brand.CreationDate,
                        Name = p.Brand.Name,
                    }
                });

            return FormatPagedList(result, page, itemsPerPage, result.Count());
        }

        private PagedList<Domain.Patrimony> FormatPagedList(IQueryable<Domain.Patrimony> list, int page, int itemsPerPage, int total)
        {
            var skip = (page - 1) * itemsPerPage;
            return new PagedList<Domain.Patrimony>()
            {
                Page = page,
                ItemsPerPage = itemsPerPage,
                TotalItems = total,
                Items = list.Skip(skip).Take(itemsPerPage).ToList()
            };
        }
        #endregion
    }
}
