using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SafetyAlertAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Adicionando o contexto do banco de dados
builder.Services.AddDbContext<AlertContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





//// Configuração do CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowedOrigins",
//        policy =>
//        {
//            policy.WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>())
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});



//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "AllowedOrigins",
//                      policy =>
//                      {
//                          policy.WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>())
//                               .AllowAnyHeader()
//                                .AllowAnyMethod();
//                      });
//});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder => builder
//            .AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder => builder
//            .AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//});




// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Habilita o CORS
//app.UseCors("AllowAll"); // Habilita o CORS
//app.UseCors("AllowedOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();






//dotnet ef migrations add InitialCreate
//dotnet ef database update
//dotnet run


//    "Location": "Latitude: -23.561684, Longitude: -46.625378",
//    "AudioFilePath": "/audio/alert123.wav",
//    "VideoFilePath": "/video/alert123.mp4"
