using Microsoft.Extensions.DependencyInjection;
using SoundBoard.Extension_Methodes;
using StackExchange.Redis;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;
//Dependency injection coming from extension method 

builder.Services.AddDatabase(configuration);
builder.Services.AddRepository();
builder.Services.AddServices();
builder.Services.AddCacheKeyDb(configuration);
builder.Services.AddAutoMapper(sdf => { }, typeof(AutoMapperProfile));
builder.Services.AddJwtAuthentication(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

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
