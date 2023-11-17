using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.BLL.Exceptions;
using ShoppingBuddy.BLL.Services.ShoppersService;
using ShoppingBuddy.BLL.Services.ShoppingItemsService;
using ShoppingBuddy.BLL.Services.ShoppingService;
using ShoppingBuddy.DAL;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySqlServerDefault"), new MySqlServerVersion(new Version(8, 0, 32))));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ONLY_FRONTEND_ALLOWED",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IShoppersService, ShoppersService>();
builder.Services.AddScoped<IShoppingItemsService, ShoppingItemsService>();
builder.Services.AddScoped<IShoppingService, ShoppingService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseExceptionHandler(applicationBuilder => applicationBuilder.Run(async httpContext =>
{
    var error = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    httpContext.Response.StatusCode = error is HttpResponseException httpResponseException ? (int)httpResponseException.StatusCode : StatusCodes.Status500InternalServerError;
    httpContext.Response.ContentType = "application/json; charset=UTF-8";
    var errorMessage = error is HttpResponseException exception ? exception.Message : "Something went wrong.";
    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { message = errorMessage }));
}));

app.UseHttpsRedirection();

app.UseCors("ONLY_FRONTEND_ALLOWED");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
