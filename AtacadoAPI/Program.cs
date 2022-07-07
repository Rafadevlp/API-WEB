using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(doc =>
{
    doc.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Atacado API - V1",
            Version = "v1"
        }
     );

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "AtacadoAPI.xml");
    doc.IncludeXmlComments(filePath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
