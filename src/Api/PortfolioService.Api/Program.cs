using Microsoft.Extensions.Configuration;
using PortfolioService.Api.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCorsPolicy(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddMongoDbClient(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddAutoMappers();
builder.Services.AddConfigurationOptions();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(builder.Configuration.GetSection("CorsPolicy:Name").Get<string>());

app.UseAuthorization();

app.MapControllers();

app.Run();
