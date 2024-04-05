using X.Application;
using X.Infrastructure;
using X.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("XApp", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins(new string[] { "http://localhost:5173" });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("XApp");

app.Run();
