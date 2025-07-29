using api;
using api.Fornecedor.Repository;
using api.Usuario.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using api.Fornecedor.Dtos;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); //busca nas configs no json
});

// Configura o Identity
builder.Services.AddIdentity<AppUserModel, IdentityRole>(options =>
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
        ValidateIssuerSigningKey = true, // valida a chave de assinatura do token 
        ValidIssuer = builder.Configuration["Jwt:Issuer"], // emissor do token
    }
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
//chama controllers
builder.Services.AddControllers(); 
//chama interfaces e repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); 
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