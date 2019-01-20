using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Demo.PatrimonyManagement.Data.Infra.Identity
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials Credentials { get; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            Credentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}