using Demo.PatrimonyManagement.Common.Crypto;
using Demo.PatrimonyManagement.Data.Infra;
using Demo.PatrimonyManagement.Data.Repository.User;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.Base;
using FluentValidation;
using System;

namespace Demo.PatrimonyManagement.Service.User
{
    public class UserService : BaseService<Domain.User>, IUserService
    {
        private const string weakPasswordMessage = "A senha não atende os requisitos. É preciso ter no mínimo oito caracteres, sendo um caractere especial, um numérico e uma letra maiúscula.";
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IValidator<Domain.User> validator) : base(repository, unitOfWork, validator)
        {
            _userRepository = repository;
        }

        public Result<Domain.User> Authenticate(Domain.User user)
        {
            var result = Validate(user, x => x.Email, x => x.Password);
            string decryptedPass = user.Password;

            user = _repository.Find(e => e.Email.Equals(user.Email, StringComparison.InvariantCultureIgnoreCase));

            if (user == null || !IsValidPassword(user, decryptedPass))
            {
                result.Messages.Add("E-mail e/ou senha incorretos");
                return result;
            }

            result.Value = Cleanup(user);
            return result;
        }

        public override Result<Domain.User> Insert(Domain.User user)
        {
            var result = Validate(user);

            if (!user.IsPasswordStrong())
                result.Messages.Add(weakPasswordMessage);

            if (_repository.Any(x => x.Email == user.Email))
                result.Messages.Add("Esse e-mail já foi cadastrado a outro usuário.");

            user.Email = user.Email.ToLowerInvariant();
            if (result.Success)
            {
                user = EncryptPassword(user);
                result.Value = _repository.Insert(user);
            }
            return result;
        }

        #region [ Private ]

        private bool IsValidPassword(Domain.User user, string decryptedPass)
        {
            return user.Password == Hash.Create(decryptedPass, user.PasswordSalt);
        }

        private Domain.User EncryptPassword(Domain.User user)
        {
            user.PasswordSalt = Salt.Create();
            user.Password = Hash.Create(user.Password, user.PasswordSalt);
            return user;
        }
        private Domain.User Cleanup(Domain.User user)
        {
            user.Password = string.Empty;
            user.PasswordSalt = string.Empty;
            return user;
        }
        #endregion
    }
}
