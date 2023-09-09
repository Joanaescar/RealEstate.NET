using RealEstate.Database;
using RealEstate.Repositories;
using RealEstate.Respositories;
using RealEstate.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<REDbContext>();

builder.Services.AddScoped<IHouseRespository, HouseRepository>(); // para adicionar ao programa os respositorios criados para house tanto interface como a implementação
builder.Services.AddScoped<IUserRepository, UserRepository>();


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
