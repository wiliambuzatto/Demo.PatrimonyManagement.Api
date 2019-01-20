using AutoMapper;
using Demo.GestaoPatrimonio.Api.ViewModels;
using Demo.PatrimonyManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.GestaoPatrimonio.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile() : this("Profile") { }

        protected ViewModelToDomainMappingProfile(string profileName) : base(profileName)
        {

            #region [ User ]
            CreateMap<LoginUserViewModel, User>();
            CreateMap<CreateUserViewModel, User>();
            #endregion

            #region [ Brand ]
            CreateMap<BrandViewModel, Brand>();
            #endregion

            #region [ Patrimony ]
            CreateMap<PatrimonyViewModel, Patrimony>();
            CreateMap<CreatePatrimonyViewModel, Patrimony>();
            #endregion
        }
    }
}
