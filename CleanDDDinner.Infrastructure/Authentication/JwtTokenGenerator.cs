using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanDDDinner.Application.Interfaces.Authentication;
using CleanDDDinner.Application.Interfaces.Services;
using CleanDDDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanDDDinner.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dtProvider, IOptions<JwtSettings> settings)
    : IJwtTokenGenerator
{
    private readonly JwtSettings _settings = settings.Value;

    public string GenerateToken(User user)
    {
        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret)),
            SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        JwtSecurityToken securityToken = new(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            expires: dtProvider.UtcNow.AddMinutes(_settings.ExpiryMinutes),
            claims: claims, 
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}