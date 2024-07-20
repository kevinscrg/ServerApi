using Microsoft.EntityFrameworkCore;
using ServerApi.Data;
using ServerApi.Repositories;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies;
using ServerApi.Servicies.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlite<AppDbContext>(connectionString);



// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Repositories
builder.Services.AddScoped<ICarteRepository, CarteRepository>();
builder.Services.AddScoped<IGenRepository, GenRepository>();
builder.Services.AddScoped<ITropeRepository, TropeRepository>();
builder.Services.AddScoped<IRecenzieRepository, RecenzieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Services
builder.Services.AddScoped<ICarteService, CarteService>();
builder.Services.AddScoped<IRecenzieService, RecenzieService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.Services.CreateScope()
    .ServiceProvider.GetRequiredService<AppDbContext>()
    .Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
