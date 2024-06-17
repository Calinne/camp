using campairbnb.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICampAirbnbDataContext, CampAirbnbDatabase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger services and include the custom operation filter
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CampAirbnb API", Version = "v1" });
    c.OperationFilter<SwaggerFileOperationFilter>(); // Include the custom file operation filter
});

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CampAirbnb API v1");
    });
}

app.UseHttpsRedirection();

// Enable CORS --- this is to allow frontend to communicate x
app.UseCors("AllowAllOrigins");

app.UseAuthorization();
app.MapControllers();
app.Run();
