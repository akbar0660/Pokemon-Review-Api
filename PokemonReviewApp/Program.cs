using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Mapping;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
// Add services to the container.

builder.Services.AddDependencies(configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conf = new MapperConfiguration(opt =>
{
    opt.AddProfile(new PokemonProfile());
    opt.AddProfile(new CategoryProfile());
    opt.AddProfile(new CountryProfile());
});

var mapper = conf.CreateMapper();
builder.Services.AddSingleton(mapper);

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