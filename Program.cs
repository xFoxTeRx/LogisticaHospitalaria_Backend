using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LogisticaHospitalariaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LogisticaHospitalariaContext")
        ?? throw new InvalidOperationException("Connection string 'LogisticaHospitalariaContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<WebhookService>();
builder.Services.AddScoped<GestionInventarioService>();

// CORS aquí arriba
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS aquí abajo, antes de todo lo demás
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();