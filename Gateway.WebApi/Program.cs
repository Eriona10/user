using AutoMapper;
using FluentAssertions.Common;
using Gateway.WebApi.Data.Entieties;


using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PetTrackerContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

/*builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())*/;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapGet("api/v1/user", async (IUserRepository repo, IMapper mapper) =>
//{
//    var users = await repo.GetAllUser();

//    return Results.Ok(mapper.Map<IEnumerable<UserReadDto>>(users));
//});


app.Run();
