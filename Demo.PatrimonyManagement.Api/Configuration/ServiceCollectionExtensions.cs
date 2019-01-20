using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Infra.Identity;
using Demo.PatrimonyManagement.Data.Repository;
using Demo.PatrimonyManagement.Data.Repository.Brand;
using Demo.PatrimonyManagement.Data.Repository.Patrimony;
using Demo.PatrimonyManagement.Data.Repository.User;
using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Validators;
using Demo.PatrimonyManagement.Service.Brand;
using Demo.PatrimonyManagement.Service.Patrimony;
using Demo.PatrimonyManagement.Service.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.GestaoPatrimonio.Api.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(
           this IServiceCollection services)
        {
            #region [ Services ]
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IPatrimonyService, PatrimonyService>();
            #endregion

            #region [ Repositories ]
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IPatrimonyRepository, PatrimonyRepository>();
            #endregion

            #region [ Validators ]
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<IValidator<Brand>, BrandValidator>();
            services.AddScoped<IValidator<Patrimony>, PatrimonyValidator>();
            #endregion

            #region [ Auth ]
            services.AddScoped<IAppSignInManager, AppSignInManager>();
            #endregion

            #region [ UnitOfWork ]
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }
    }
}
