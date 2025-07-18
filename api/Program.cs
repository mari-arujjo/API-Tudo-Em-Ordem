using api;
using api.Fornecedor.Repository;
using api.Usuario.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); //busca nas configs no json
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

// AQUI: aplicar o CORS antes dos endpoints
app.UseCors("PermitirLocalhost");

app.MapControllers();

app.Run();