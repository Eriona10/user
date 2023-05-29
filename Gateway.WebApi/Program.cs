////Swasgger
//using AutoMapper;
//using FluentAssertions.Common;
//using Gateway.WebApi.Data.Entieties;
//using Gateway.WebApi.Dtos.User;

//using Microsoft.AspNetCore.Identity;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Validations;
//using Ocelot.Values;
//using User.Microservice.Data;
//using User.Microservice.Models;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddDbContext<PetTrackerContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});


//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
//app.Run();


//////Automapper

////using AutoMapper;
////using Gateway.WebApi.Data.Entieties;
////using Gateway.WebApi.Dtos.User;
////using Gateway.WebApi.Repository.User;
////using Microsoft.AspNetCore.Builder;
////using Microsoft.Data.SqlClient;
////using Microsoft.EntityFrameworkCore;
////using Microsoft.OpenApi.Validations;

////var builder = WebApplication.CreateBuilder(args);


////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////var sqlConBuilder = new SqlConnectionStringBuilder();
////sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

////builder.Services.AddDbContext<PetTrackerContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

////builder.Services.AddScoped<IUserRepository, UserRepository>();


////builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();

////localhost:548954/api/v1/cattles
////perdorimi i repository, mapper per mshefjen e struktures se databazes nga end-user 
////app.MapGet("api/v1/user", async (IUserRepository repo, IMapper mapper) =>
////{
////    var User = await repo.GetAllUser();

////    return Results.Ok(mapper.Map<IEnumerable<UserReadDto>>(User));
////});

//////erdorimi i dbcontextit per nxjerrje te te dhenave nga databaza pa readdto
////app.MapGet("api/v1/user", async (PetTrackerContext context) =>
////{
////    var user = await context.AspNetUsers.ToListAsync();

////    return Results.Ok(user);
////});

////app.MapGet("api/v1/cattles/{id}", async (IUserRepository repo, IMapper mapper, int id) =>
////{
////    var cattle = await repo.GetCattleById(id);
////    if (cattle is not null)
////    {
////        return Results.Ok(mapper.Map<CattleReadDto>(cattle));
////    }
////    else
////    {
////        return Results.NotFound(new { error = "not found" });
////    }

////});

////app.MapPost("api/v1/user", async (IUserRepository repo, IMapper mapper, UserCreateDto cattle) =>
////{
////    if (cattle is not null)
////    {
////        var mapped_object = mapper.Map<AspNetUsers>(cattle);
////        await repo.CreateUser(mapped_object);
////        await repo.SaveChanges();

////        var result = mapper.Map<UserReadDto>(mapped_object);

////        return Results.Created($"Gjedhja me id {result.Id} u krijua!", result);
////    }
////    return Results.NoContent();
////});

////app.Run();

////Youtube
////using AutoMapper;
////using FluentAssertions.Common;
////using Gateway.WebApi.Data.Entieties;
////using Gateway.WebApi.Dtos.User;
////using Gateway.WebApi.Repository.User;
////using Microsoft.AspNetCore.Authorization;
////using Microsoft.AspNetCore.Identity;
////using Microsoft.Data.SqlClient; 
////using Microsoft.EntityFrameworkCore;
////using Microsoft.OpenApi.Validations;
////using Ocelot.Values;
////using User.Microservice.Data;
////using User.Microservice.Models;

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.

////builder.Services.AddControllers();
////builder.Services.AddDbContext<PetTrackerContext>(options =>
////{
////    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
////});


////builder.Services.AddScoped<IUserRepository, UserRepository>();


////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();


////var app = builder.Build();


////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();

////app.UseAuthorization();

////app.MapControllers();

////app.Run();
global using Gateway.WebApi.Data;
global using Microsoft.EntityFrameworkCore;
using FluentAssertions.Common;
using Gateway.WebApi.Data.Entieties;
using Microsoft.AspNetCore.Identity;
using Ocelot.Values;
using User.Microservice.Data;
using User.Microservice.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PetTrackerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<ApplicationRole>()
  .AddEntityFrameworkStores<PetTrackerContext>();


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