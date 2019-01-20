using Demo.GestaoPatrimonio.UnitTest;
using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Repository;
using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Domain.Validators;
using Demo.PatrimonyManagement.Service.Patrimony;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Demo.PatrimonyManagement.UnitTest.Services
{
    public class PatrimonyServiceTest
    {
        readonly Mock<IPatrimonyService> patrimonyServiceMock;
        readonly Mock<IPatrimonyRepository> patrimonyRepositoryMock;
        readonly Mock<IUnitOfWork> unitOfWorkMock;

        public PatrimonyServiceTest()
        {
            patrimonyServiceMock = new Mock<IPatrimonyService>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            patrimonyRepositoryMock = new Mock<IPatrimonyRepository>();

            patrimonyRepositoryMock.Setup(repo => repo.Insert(It.IsAny<Patrimony>())).Returns(() =>
            {
                return new Patrimony()
                {
                    Name = "Patrimônio 1",
                    Description = "Descrição do Patrimônio 1",
                    BrandId = new Guid("FE29238C-A6F3-41DF-816C-08D67EF9B8D1"),
                    TippingNumber = new Guid("4C353108-FF98-4E7A-A72E-C215FCC999B4")
                };
            });

            patrimonyRepositoryMock.Setup(service => service.Insert(It.IsAny<Patrimony>())).Verifiable();
        }

        [Fact]
        public void ShouldReturnTrueWhenInsertPatrimony()
        {
            Thread.CurrentPrincipal = new UserMock().GetClaimsUser();

            var service = new PatrimonyService(patrimonyRepositoryMock.Object,
                unitOfWorkMock.Object, new PatrimonyValidator());

            Result<Patrimony> result = service.Insert(new Patrimony()
            {
                Name = "Patrimônio 2",
                Description = "Descrição do Patrimônio 2",
                BrandId = new Guid("FE29238C-A6F3-41DF-816C-08D67EF9B8D1"),
            });
            Assert.NotNull(result);
            Assert.True(result.Success);
        }


    }
}
