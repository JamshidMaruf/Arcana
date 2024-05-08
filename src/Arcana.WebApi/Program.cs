using Arcana.DataAccess.Contexts;
using Arcana.Service.Helpers;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Helpers;
using Arcana.WebApi.Mappers;
using Arcana.WebApi.Validators.Users;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
    options.Conventions.Add(new RouteTokenTransformerConvention(new RouteHelper())));
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection")));

builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddExceptionHandlers();
builder.Services.AddProblemDetails();

builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddValidators();
builder.Services.AddApiServices();
builder.Services.AddServices();


var app = builder.Build();
app.AddInjectHelper();
app.InjectEnvironmentItems();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
