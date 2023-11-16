using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.BLL.Services.ShoppersService;
using ShoppingBuddy.BLL.Services.ShoppingItemsService;
using ShoppingBuddy.DAL;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySqlServerDefault"), new MySqlServerVersion(new Version(8, 0, 32))));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IShoppersService, ShoppersService>();
builder.Services.AddScoped<IShoppingItemsService, ShoppingItemsService>();

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

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
