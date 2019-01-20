using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Repository.Pattern;
using Demo.PatrimonyManagement.Domain.Common;
using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Demo.PatrimonyManagement.Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IRepositoryPattern<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IValidator<TEntity> _validator;

        public BaseService(IRepositoryPattern<TEntity> repository, IUnitOfWork unitOfWork, IValidator<TEntity> validator)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        #region GET
        public bool Any(Expression<Func<TEntity, bool>> filter) => _repository.Any(filter);
        public int Count(Expression<Func<TEntity, bool>> filter) => _repository.Count(filter);
        public virtual TEntity Find(params object[] keyValues) => _repository.Find(keyValues);
        public virtual PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage)
            => _repository.Get(filter, order, page, itemsPerPage);
        public PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage)
            => _repository.Get(order, page, itemsPerPage);
        #endregion


        protected Result<TEntity> Validate(TEntity entity) => new Result<TEntity>(_validator.Validate(entity));
        protected Result<TEntity> Validate(TEntity entity, params Expression<Func<TEntity, object>>[] filter) => new Result<TEntity>(_validator.Validate(entity, filter));


        public virtual Result<TEntity> Insert(TEntity entity)
        {
            var result = Validate(entity);

            if (result.Success)
                result.Value = _repository.Insert(entity);

            return result;
        }
        public virtual Result<TEntity> Update(TEntity entity)
        {
            var result = Validate(entity);

            if (result.Success)
                result.Value = _repository.Update(entity);

            return result;
        }
        public Result Delete(params object[] keyValues)
        {
            _repository.Delete(keyValues);
            return new Result();
        }
    }
}