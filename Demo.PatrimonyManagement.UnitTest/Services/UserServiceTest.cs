using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Infra.Identity;
using Demo.PatrimonyManagement.Data.Repository.User;
using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Domain.Validators;
using Demo.PatrimonyManagement.Service.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Xunit;

namespace Demo.GestaoPatrimonio.UnitTest.Services
{
    public class UserServiceTest
    {
        readonly Mock<IUserService> userServiceMock;
        readonly Mock<IAppSignInManager> appSignManagerMock;
        readonly Mock<IUserRepository> userRepositoryMock;
        readonly Mock<IUnitOfWork> unitOfWorkMock;

        private const string PASSWORD_HASH = "jEtO+rxdl3yIc/cvt3KQLKYZTGkMPMgfZFobTho6ZZA=";
        private const string PASSWORD_SALT = "Utf0MoqLta9CtDSChowrqQ==";

        public UserServiceTest()
        {
            userServiceMock = new Mock<IUserService>();
            appSignManagerMock = new Mock<IAppSignInManager>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            userRepositoryMock = new Mock<IUserRepository>();
            Thread.CurrentPrincipal = new UserMock().GetClaimsUser();

            userRepositoryMock.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(() =>
            {
                return new User()
                {
                    Email = "maria@gmail.com",
                    Password = "S&nh@F0rt&",
                    Name = "Maria da Silva"
                };
            });

            userRepositoryMock.Setup(repo => repo.Update(It.IsAny<User>())).Returns(() =>
            {
                return new User()
                {
                    Email = "maria@gmail.com",
                    Password = "S&nh@F0rt&",
                    Name = "Maria da Silva"
                };
            });

            userRepositoryMock.Setup(repo => repo.Find(It.IsAny<Expression<Func<User, bool>>>())).Returns(() =>
            {
                return new User()
                {
                    Id = new Guid("836969C9-1E93-4DBD-91DD-1422CB3120D4"),
                    Email = "maria@gmail.com",
                    Name = "Maria da Silva",
                    Password = PASSWORD_HASH,
                    PasswordSalt = PASSWORD_SALT,
                };
            });

            userRepositoryMock.Setup(repo => repo.Get()).Returns(() =>
            {
                return new List<User>()
                {
                    new User()
                        {
                            Id = Guid.NewGuid(),
                            Email = "maria@gmail.com",
                            Name = "Maria da Silva",
                            Password = PASSWORD_HASH,
                            PasswordSalt = PASSWORD_SALT
                        },
                    new User()
                     {
                            Id = Guid.NewGuid(),
                            Email = "jose@gmail.com",
                            Name = "José da Silva",
                            Password = "gFXh9anwFvpIv/2ubK+Qg2gLeVYg5k7Tv/kloJMLKJQ=",
                            PasswordSalt = "f1gOxczbwSFJY94qUholIQ=="
                    }
                }.AsQueryable();
            });

            userServiceMock.Setup(service => service.Insert(It.IsAny<User>())).Verifiable();
        }

        #region [ Register ]
        [Fact]
        public void ShouldReturnFalseWhenRegisterInvalidUser()
        {

            var service = new UserService(userRepositoryMock.Object, unitOfWorkMock.Object, new UserValidator());

            Result<User> result = service.Insert(new User()
            {
                Email = "",
                Password = ""
            });
            Assert.NotNull(result);
            Assert.False(result.Success);
        }
        #endregion

        #region [ Update ]
        [Fact]
        public void ShouldReturnFalseWhenUpdateInvalidUser()
        {
            var service = new UserService(userRepositoryMock.Object, unitOfWorkMock.Object, new UserValidator());

            Result<User> result = service.Update(new User()
            {
                Email = "",
                Name = "",
            });

            Assert.NotNull(result);
            Assert.False(result.Success);
        }
        #endregion


    }
}
