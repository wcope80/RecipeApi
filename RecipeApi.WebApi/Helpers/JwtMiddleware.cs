using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using RecipeApi.WebApi.Models;
using RecipeApi.WebApi.Services.Authentication.Interfaces;

namespace RecipeApi.WebApi.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JWTKey _appSettings;
    private readonly ILogger<JwtMiddleware> _logger;

    public JwtMiddleware(RequestDelegate next, IOptions<JWTKey> appSettings, ILogger<JwtMiddleware> logger)
    {
        _next = next;
        _appSettings = appSettings.Value;
        _logger = logger;

    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            AttachUserToContext(context, userService, token);

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetById(userId);
        }
        catch
        {
            _logger.LogInformation($"AttachUserToContext failed for token { token }");
        }
    }
}