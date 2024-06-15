using Api.Data;
using Api.Mapper;
using Api.Repository;
using Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configuración Conexión SQLServer
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("connectionSql"));
});

// Add services to the container.

builder.Services.AddScoped<IHumanoRepository, HumanoRepository>();

//Agregamos Automapper
builder.Services.AddAutoMapper(typeof(APIMappers));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//CORS
//Se puede habilitar: 1-Un dominio, 2-multiples dominios
//3-cualquier dominio (Tener en cuenta Seguridad)
//Usamos de Ejemplo el dominio: http://localhost:3223, se debe cambiar por el correcto
//Se usa (*) para todos los dominios
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//CORS
app.UseCors("PolicyCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
