using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURACIÓN DEL PUERTO PARA RAILWAY (Añade esto aquí)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddDbContext<LogisticaHospitalariaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LogisticaHospitalariaContext")
        ?? throw new InvalidOperationException("Connection string 'LogisticaHospitalariaContext' not found.")));

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<GestionInventarioService>();

builder.Services.AddCors();

var app = builder.Build();

// 2. FORZAR SWAGGER EN PRODUCCIÓN (Quitamos el "if")
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// 3. COMENTA ESTA LÍNEA (Railway maneja el HTTPS por fuera, a veces da error si se deja activa)
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
builder.Services.AddHttpClient();