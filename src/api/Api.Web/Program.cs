using Infrastructure.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache();
builder.Services.AddDbContextFactory<ApplicationDbContext>((provider, options) =>
{
	var memoryCache = provider.GetRequiredService<IMemoryCache>();
	var configuration = provider.GetRequiredService<IConfiguration>();

	options.UseMemoryCache(memoryCache);
	options.UseCamelCaseNamingConvention();

	var conStringBuilder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("PostgreSql"));
	conStringBuilder.Password = configuration["PostgreSql:Password"];

	options.UseNpgsql(conStringBuilder.ConnectionString);
});
builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
