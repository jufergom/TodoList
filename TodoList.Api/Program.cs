using System.Net;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Namespace;
using TodoList.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default")),
        options => options.EnableRetryOnFailure(
                    maxRetryCount: 1,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
    )
);

//add repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//add services
builder.Services.AddScoped<IRoleService, RoleService>();
//add result mapping on controller level
builder.Services.AddControllers(mvcOptions => mvcOptions
    .AddResultConvention(resultStatusMap => resultStatusMap
        .AddDefaultMap()
        .For(ResultStatus.Ok, HttpStatusCode.OK, resultStatusOptions => resultStatusOptions
            .For("POST", HttpStatusCode.Created)
            .For("PUT", HttpStatusCode.Created)
            .For("DELETE", HttpStatusCode.NoContent))
        .For(ResultStatus.Error, HttpStatusCode.InternalServerError)
    ));

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
