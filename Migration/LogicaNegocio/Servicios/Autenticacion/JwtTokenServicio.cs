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

        public async Task<string> GenerarToken(string IdEmpleado)
        {
            var usuario = _configuration["Jwt:Usuario"];
            var llaveSecreta = _configuration["Jwt:LlaveSecreta"];

            if(llaveSecreta == null)
            {
                throw new Exception("Error al cargar el Token.");
            }

            var llave = Encoding.UTF8.GetBytes(llaveSecreta);

            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, IdEmpleado)
                });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer=usuario,
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
    }
}
