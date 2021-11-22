﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib;
using EfEx;
using EfEx.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebServiceToken.Middleware
{
    public static class JwtAuthMiddlewareExtension
    {
        public static IApplicationBuilder UseJwtAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtAuthMiddleware>();
        }
    }

    public class JwtAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDataService _dataService;
        private readonly IConfiguration _configuration;

        public JwtAuthMiddleware(RequestDelegate next, IDataService dataService, IConfiguration configuration)
        {
            _next = next;
            _dataService = dataService;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var key = Encoding.UTF8.GetBytes(_configuration.GetSection("Auth:Secret").Value);

                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;
                var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == "id");
                if (claim != null)
                {
                    int.TryParse(claim.Value.ToString(), out var id);
                    context.Items["User"] = _dataService.GetUser(id);
                }
            }
            catch { }

            await _next(context);
        }
    }
}