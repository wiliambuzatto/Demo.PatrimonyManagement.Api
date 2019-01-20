using AutoMapper;
using Demo.GestaoPatrimonio.Api.ViewModels;
using Demo.PatrimonyManagement.Domain;

namespace Demo.GestaoPatrimonio.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : this("Profile") { }

        protected DomainToViewModelMappingProfile(string profileName) : base(profileName)
        {
            #region [ User ]
            CreateMap<User, UserViewModel>();
            #endregion

            #region [ Brand ]
            CreateMap<Brand, BrandViewModel>();
            #endregion

            #region [ Patrimony ]
            CreateMap<Patrimony, PatrimonyViewModel>();
            #endregion
        }
    }
}
