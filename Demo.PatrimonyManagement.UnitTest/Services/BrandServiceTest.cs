using Demo.GestaoPatrimonio.UnitTest;
using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Repository.Brand;
using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Domain.Validators;
using Demo.PatrimonyManagement.Service.Brand;
using Moq;
using System.Threading;
using Xunit;

namespace Demo.PatrimonyManagement.UnitTest.Services
{
    public class BrandServiceTest
    {
        readonly Mock<IBrandService> brandServiceMock;
        readonly Mock<IBrandRepository> brandRepositoryMock;
        readonly Mock<IUnitOfWork> unitOfWorkMock;

        public BrandServiceTest()
        {
            brandServiceMock = new Mock<IBrandService>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            brandRepositoryMock = new Mock<IBrandRepository>();

            brandRepositoryMock.Setup(repo => repo.Insert(It.IsAny<Brand>())).Returns(() =>
            {
                return new Brand()
                {
                    Name = "Marca 1"
                };
            });

            brandServiceMock.Setup(service => service.Insert(It.IsAny<Brand>())).Verifiable();
        }

        [Fact]
        public void ShouldReturnTrueWhenInsertBrand()
        {
            Thread.CurrentPrincipal = new UserMock().GetClaimsUser();

            var service = new BrandService(brandRepositoryMock.Object,
                unitOfWorkMock.Object, new BrandValidator());

            Result<Brand> result = service.Insert(new Brand()
            {
                Name = "Marca 2"
            });
            Assert.NotNull(result);
            Assert.True(result.Success);
        }


    }
}
