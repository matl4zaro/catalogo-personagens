using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace api_catalogo_personagens.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SegurancaController : ControllerBase
{
    private readonly IConfiguration _configuracao;

    public SegurancaController(IConfiguration configuracao)
    {
        _configuracao = configuracao;
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] User loginDetails)
    {
        bool resultado = ValidarUsuario(loginDetails);
        if (resultado)
        {
            var tokenString = _GerarTokenJwt();
            return Ok(new { token = tokenString });
        }
        else
        {
            return Unauthorized();
        }
    }
    private bool ValidarUsuario(User loginDetails)
    {
        if (loginDetails.Usuario == "teste" && loginDetails.Senha == "123")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private string _GerarTokenJwt()
    {
        ConfiguracaoToken configuracaoToken = new();
        new ConfigureFromConfigurationOptions<ConfiguracaoToken>(_configuracao.GetSection("JWT")).Configure(configuracaoToken);

        byte[] chaveEmBytes = Encoding.UTF8.GetBytes(configuracaoToken.Key);
        SymmetricSecurityKey securityKey = new(chaveEmBytes);

        string algoritmo = SecurityAlgorithms.HmacSha256;
        SigningCredentials credentials = new(securityKey, algoritmo);

        JwtSecurityToken jwtToken = new(
            issuer: configuracaoToken.Issuer,
            audience: configuracaoToken.Audience,
            expires: DateTime.Now.AddMinutes(configuracaoToken.Expires),
            signingCredentials: credentials
        );
        JwtSecurityTokenHandler manipuladorToken = new();
        string tokenEmString = manipuladorToken.WriteToken(jwtToken);

        return tokenEmString;
    }
}

public class User
{
    //public Guid Id { get; set; }
    public string Usuario { get; set; } = "";
    public string Senha { get; set; } = "";
}