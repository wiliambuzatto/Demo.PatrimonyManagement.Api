using Demo.PatrimonyManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.PatrimonyManagement.Data.Infra.Identity
{
    public interface IAppSignInManager
    {
        object GenerateToken(User user, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations);
    }
}
