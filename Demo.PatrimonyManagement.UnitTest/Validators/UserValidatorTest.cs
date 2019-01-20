using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Validators;
using FluentValidation.Results;
using Xunit;

namespace Demo.GestaoPatrimonio.UnitTest.Validators
{
    public class UserValidatorTest
    {
        private UserValidator userValidator;
        private User user;

        public UserValidatorTest()
        {
            userValidator = new UserValidator();
            user = new User();
        }

        [Fact]
        public void ShouldReturnValidWhenValidateUser()
        {
            user = new User()
            {
                Email = "maria@gmail.com",
                Password = "P@ssw0rd123",
                Name = "Maria da Silva"
            };

            ValidationResult result = userValidator.Validate(user);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenValidateUser()
        {
            user = new User()
            {
                Email = null,
                Password = null,
                Name = null,
            };

            ValidationResult result = userValidator.Validate(user);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnFalseWhenPasswordHasOnlyNumbers()
        {
            user.Password = "1234";
            Assert.False(user.IsPasswordStrong());
        }

        [Fact]
        public void ShouldReturnFalseWhenPasswordHasOnlyLetters()
        {
            user.Password = "pass";
            Assert.False(user.IsPasswordStrong());
        }

        [Fact]
        public void ShouldReturnFalseWhenPasswordHasSpecialCharacter()
        {
            user.Password = "1234.pass";
            Assert.False(user.IsPasswordStrong());
        }

        [Fact]
        public void ShouldReturnFalseWhenPasswordIsWeak()
        {
            user.Password = "password123";
            Assert.False(user.IsPasswordStrong());
        }

        [Fact]
        public void ShouldReturnTrueWhenPasswordIsStrong()
        {
            user.Password = "P@ssw0rd123";
            Assert.True(user.IsPasswordStrong());
        }
    }
}
