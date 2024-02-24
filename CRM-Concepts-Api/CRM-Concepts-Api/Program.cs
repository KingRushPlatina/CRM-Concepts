using CRM_Concepts_Api.DBContext;
using CRM_Concepts_Api.DBContext.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using CRM_Concepts_Api.Controllers;
using CRM_Concepts_Api.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ICRMContext,CRMContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CRM-Concepts"));
});

builder.Services.AddScoped<IClientManager, ClientManager>();
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext= scope.ServiceProvider.GetRequiredService<ICRMContext>();
    if(!dbContext.Database.CanConnect())
    {
        throw new NotImplementedException("Can't connect to Db");
    }
 
}

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
