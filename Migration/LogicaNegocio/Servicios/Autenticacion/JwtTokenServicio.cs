using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Qcode.BusinessLogic.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Qcode.BusinessLogic.Servicios.Autenticacion
{
    public class JwtTokenServicio : IJwtTokenServicio
    {

        private readonly IConfiguration _configuration;

        public JwtTokenServicio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerarToken(string idEmpleado)
        {
            var Issuer = _configuration["Jwt:Issuer"];
            var Key = _configuration["Jwt:Key"];

            if(Key == null)
            {
                throw new Exception("Error al cargar el Token.");
            }

            var llave = Encoding.UTF8.GetBytes(Key);

            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, idEmpleado)
                });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer=Issuer,
                Subject =claims,
                Expires= DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(llave),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
        
        public async Task ValidarToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                }, out SecurityToken validatedToken);

                Console.WriteLine(claimsPrincipal.Identity.Name);
                foreach (var claim in claimsPrincipal.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
