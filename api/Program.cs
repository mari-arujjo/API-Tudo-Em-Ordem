using api;
using api.Fornecedor.Repository;
using api.Usuario.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using api.Fornecedor.Dtos;
using Microsoft.AspNetCore.Builder;
using api.AppUserIdentity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using api.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); //busca nas configs no json
});

// Configura o Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false; // numeros obrigatorios na senha
    options.Password.RequireLowercase = false; // letras minusculas obrigatorias na senha
    options.Password.RequireUppercase = false; // letras maiusculas obrigatorias na senha
    options.Password.RequireNonAlphanumeric = false; // caracteres especiais obrigatorios na senha
    options.Password.RequiredLength = 5; // tamanho minimo da senha
}).AddEntityFrameworkStores<ApplicationDBContext>();

//Configura o JWT
builder.Services.AddAuthentication(options =>
{
   options.DefaultAuthenticateScheme =
   options.DefaultChallengeScheme =
   options.DefaultForbidScheme =
   options.DefaultScheme = 
   options.DefaultSignInScheme =
   options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // valida a chave de assinatura do token 
        ValidIssuer = builder.Configuration["JWT:Issuer"], // emissor do token
        ValidateAudience = true, // valida o publico do token
        ValidAudience = builder.Configuration["JWT:Audience"], // audiencia do token
        ValidateIssuerSigningKey = true, // valida a chave de assinatura do token
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(
                builder.Configuration["JWT:SigningKey"] // chave de assinatura do token
            )
        )
    };
});

// HABILITAR CORS
builder.Services.AddCors(options =>
{  
    options.AddPolicy("PermitirLocalhost", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});



//chama controllers
builder.Services.AddControllers();
//chama interfaces e repositorios
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEditarPerfilRepository, EditarPerfilRepository>(); 
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Habilita a autenticação
app.UseAuthorization(); // Habilita a autorização

// AQUI: aplicar o CORS antes dos endpoints
app.UseCors("PermitirLocalhost");

app.MapControllers();

app.Run();