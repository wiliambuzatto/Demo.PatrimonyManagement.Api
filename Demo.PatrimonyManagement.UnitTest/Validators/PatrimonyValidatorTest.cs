using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Validators;
using FluentValidation.Results;
using System;
using Xunit;

namespace Demo.GestaoPatrimonio.UnitTest.Validators
{
    public class PatrimonyValidatorTest
    {
        private PatrimonyValidator patrimonyValidator;
        private Patrimony patrimony;

        public PatrimonyValidatorTest()
        {
            patrimonyValidator = new PatrimonyValidator();
            patrimony = new Patrimony();
        }

        [Fact]
        public void ShouldReturnValidWhenValidatePatrimony()
        {
            patrimony = new Patrimony()
            {
                Name = "Patrimônio 1",
                Description = "Descrição do Patrimônio 1",
                BrandId = Guid.NewGuid()
            };

            ValidationResult result = patrimonyValidator.Validate(patrimony);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenValidatePatrimonyWithoutName()
        {
            patrimony = new Patrimony()
            {
                Name = null,
                Description = "Descrição do Patrimônio 1",
                BrandId = Guid.NewGuid()
            };

            ValidationResult result = patrimonyValidator.Validate(patrimony);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenValidatePatrimonyWithoutBrandId()
        {
            patrimony = new Patrimony()
            {
                Name = "Patrimônio 1",
                Description = "Descrição do Patrimônio 1",
                BrandId = new Guid(),
            };

            ValidationResult result = patrimonyValidator.Validate(patrimony);
            Assert.False(result.IsValid);
        }
    }
}
