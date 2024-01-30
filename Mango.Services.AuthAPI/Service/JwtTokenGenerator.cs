﻿using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mango.Services.AuthAPI.Service
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly JwtOptions _jwtOptions;
		public JwtTokenGenerator(JwtOptions jwtOptions)
		{
			_jwtOptions = jwtOptions;
		}
		public string GenerateToken(ApplicationUser applicatioUser)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

			var claimList = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Email, applicatioUser.Email),
				new Claim(JwtRegisteredClaimNames.Sub, applicatioUser.Id),
				new Claim(JwtRegisteredClaimNames.Name, applicatioUser.UserName.ToString())
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Audience = _jwtOptions.Audience,
				Issuer = _jwtOptions.Issuer,
				Subject = new ClaimsIdentity(claimList),
				Expires = DateTime.UtcNow.AddDays(1000),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
