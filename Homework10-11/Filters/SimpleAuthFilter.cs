using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HomeWork10.Filters
{
    public class SimpleAuthFilter : Attribute, IAuthorizationFilter // вся эта штука не работает вместе со встроенным атрибутом [Authorize]
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {		
			var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
			

			if (!ValidateCurrentToken(token) || String.IsNullOrEmpty(GetEmailFromClaim(token))) // просто проверяем валидность токена и наличие данных в клайме "sub"
				context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);			
		}

		private bool ValidateCurrentToken(string token)
		{
			var mySecret = "hello hellohrthrthrhrhrh";
			var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecret));

			var myIssuer = "http://localhost:5000";
			var myAudience = "http://localhost:5000";

			var tokenHandler = new JwtSecurityTokenHandler();

			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = myIssuer,
					ValidAudience = myAudience,
					IssuerSigningKey = mySecurityKey
				}, out SecurityToken validatedToken);
			}
			catch
			{
				return false;
			}
			return true;
		}

		private string GetEmailFromClaim(string token)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

				var stringClaimValue = securityToken.Claims.First(claim => claim.Type == "sub").Value;
				return stringClaimValue;
			}
            catch
            {
				return null;
            }
		}
	}
}
