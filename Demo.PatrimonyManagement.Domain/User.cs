using Demo.PatrimonyManagement.Domain.Common;
using System.Text.RegularExpressions;

namespace Demo.PatrimonyManagement.Domain
{
    public class User: BaseEntity
    {
        public string Name{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public bool IsPasswordStrong()
        {
            Regex rgx = new Regex(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])[A-Za-z0-9\d$@$!%_*_?&#.,-_:;]{8,}");
            return (!string.IsNullOrEmpty(Password) && rgx.IsMatch(Password));
        }
    }
}
