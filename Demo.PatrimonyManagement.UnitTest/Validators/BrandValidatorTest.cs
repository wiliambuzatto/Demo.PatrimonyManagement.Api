using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Validators;
using FluentValidation.Results;
using Xunit;

namespace Demo.GestaoPatrimonio.UnitTest.Validators
{
    public class BrandValidatorTest
    {
        private BrandValidator brandValidator;
        private Brand brand;

        public BrandValidatorTest()
        {
            brandValidator = new BrandValidator();
            brand = new Brand();
        }

        [Fact]
        public void ShouldReturnValidWhenValidateBrand()
        {
            brand = new Brand()
            {
                Name = "Marca 1"
            };

            ValidationResult result = brandValidator.Validate(brand);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenValidateBrand()
        {
            brand = new Brand()
            {
                Name = null,
            };

            ValidationResult result = brandValidator.Validate(brand);
            Assert.False(result.IsValid);
        }
    }
}
