using Microsoft.EntityFrameworkCore;
using NajotNur.Application;
using NajotNur.Application.Repositories.UserRepositories;
using NajotNur.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};Persist Security Info=True;User ID = SA;Password={dbPassword};Connect Timeout = 30;Encrypt=False;TrustServerCertificate=True;Application Intent = ReadWrite;MultipleActiveResultSets=false;MultiSubnetFailover=True; Application Name=Ovit_Software;Pooling=True;";
//var con = "Server=DOTNET-DEVELOPE; Database=NajotNurDB; Trusted_connection = true; TrustServerCertificate = true;";

builder.Services.AddDbContext<NajotNurDbContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
