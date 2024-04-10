using FirstWebApi.Authority;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace FirstWebApi.Controllers
{
    [ApiController]
    public class AuthorityController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthorityController(IConfiguration configuration)// on configuration ctrl+. create and assign field 'configeration'
        {
            this.configuration = configuration;
        }
        
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody]AppCredential credential)
        {
            if (AppRepository.Authenticate(credential.ClientId, credential.Secret))
            {
                var expiresAt = DateTime.UtcNow.AddMinutes(10);
                
                return Ok(new
                {
                    access_token = CreateToken(credential.ClientId, expiresAt),
                    expires_at = expiresAt
                });
            }
            else
            {
                ModelState.AddModelError("Unauterized", "You are not authorized");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status401Unauthorized
                };
                return new UnauthorizedObjectResult(problemDetails);
            }
        }

        private string CreateToken(string clientId, DateTime expiresAt)
        {
            // Algo
            //Payload (claims)
            //signing key -->signature
            var app = AppRepository.GetApplicationByClientId(clientId);

            var claims = new List<Claim>
            {
                new Claim("AppName", app?.ApplicationName??string.Empty),
                new Claim("Read", (app?.Scopes??string.Empty).Contains("read")?"true":"false"),
                new Claim("Write", (app?.Scopes??string.Empty).Contains("write")?"true":"false")
            };
            
            var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));

            var jwt = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature),
                claims: claims,
                expires: expiresAt,
                notBefore: DateTime.UtcNow
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        
    }
}