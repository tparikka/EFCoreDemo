using EFCoreDemo.Application.Common.Interfaces;
using EFCoreDemo.Infrastructure.Persistence;
using EFCoreDemo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInRuleDbContext, InRuleDbContext>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<InRuleDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("EFCoreScratchDatabase"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine));

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