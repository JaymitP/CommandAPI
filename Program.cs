using Commands.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// For PATCH requests to work, the JSON serializer must be set to camelCase
builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper is available to the entire application through dependency injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure the database context for dependency injection -> adds the context to the container
builder.Services.AddDbContext<CommandsContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("CommandsConnection")));

//Dependacy injection - design pattern to seperate the creation of an object from its use -> decoupling
//Service container provides an instance of the repo interface to the controller when the interface is requested
//Implementation only has to be changed in one place.
builder.Services.AddScoped<ICommandsRepo, SqlCommandsRepo>();

// builder.Services.AddScoped<ICommandsRepo, MockCommandsRepo>();

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
