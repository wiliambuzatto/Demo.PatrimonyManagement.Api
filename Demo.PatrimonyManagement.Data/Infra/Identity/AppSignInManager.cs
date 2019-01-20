﻿using Demo.PatrimonyManagement.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Demo.PatrimonyManagement.Data.Infra.Identity
{
    public class AppSignInManager : IAppSignInManager
    {
        public object GenerateToken(User user, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                    }
                );

            DateTime creationDate = DateTime.Now;
            DateTime expireDate = creationDate + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.Credentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expireDate
            });
            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = creationDate,
                expiration = expireDate,
                accessToken = token,
                name = user.Name,
                email = user.Email,
                userId = user.Id,
                message = "OK"
            };
        }
    }
}
