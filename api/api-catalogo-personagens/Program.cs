using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var servicos = builder.Services;
        var gerenciadorConfiguracoes = builder.Configuration;

        servicos.AddControllers();
        servicos.AddEndpointsApiExplorer();
        
        _configuraSwagger(servicos);
        // JWT TOKEN
        _ConfiguraAutenticacaoJWT(servicos, gerenciadorConfiguracoes);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.EnablePersistAuthorization();
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void _configuraSwagger(IServiceCollection servicos)
    {
        servicos.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CatalogoPersonagensAPI",
                Version = "v1"
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = """
                    JWT Authorization Header - utilizado com Bearer Authentication.
                    Digite 'Bearer'[espaço] e então seu token no campo abaixo.
                    Exemplo (informar sem as aspas): 'Bearer eyJhbGciOiJI...'
                    """,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    private static void _ConfiguraAutenticacaoJWT(IServiceCollection servicos, ConfigurationManager gerenciadorConfiguracoes)
    {
        var configuracaoToken = new ConfiguracaoToken();
        new ConfigureFromConfigurationOptions<ConfiguracaoToken>(gerenciadorConfiguracoes.GetSection("JWT")).Configure(configuracaoToken);


        var inicioSessaoConfiguracao = new ConfiguracaoIniciarSessao(configuracaoToken.Key ?? "");
        servicos.AddSingleton(inicioSessaoConfiguracao);
        servicos.AddSingleton(configuracaoToken);
        servicos.AddAuthentication(authOptions =>
        {
            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOptions =>
        {
            var paramsValidation = bearerOptions.TokenValidationParameters;
            paramsValidation.IssuerSigningKey = inicioSessaoConfiguracao.Key;
            paramsValidation.ValidAudience = configuracaoToken.Audience;
            paramsValidation.ValidIssuer = configuracaoToken.Issuer;

            paramsValidation.ValidateIssuerSigningKey = true;
            paramsValidation.ValidateLifetime = true;

            // Tempo de tolerância para a expiração de um token (utilizado
            // caso tenha necessidade de configurar
            // paramsValidation.ClockSkew = TimeSpan.Zero;
        });

        servicos.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build()
            );
        });
    }
}

// TODO: passar para model de segurança
public class ConfiguracaoToken 
{
    public string Key { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Audience { get; set; } = "";
    public int Expires { get; set; }
}

public class ConfiguracaoIniciarSessao
{
    public Guid Id { get; } = Guid.NewGuid();
    public SecurityKey Key { get; }
    public SigningCredentials SigningCredentials { get; }

    public ConfiguracaoIniciarSessao(string secretJwtKey)
    {
        Key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretJwtKey));

        SigningCredentials = new(
            Key, SecurityAlgorithms.HmacSha256Signature);
    }
}

