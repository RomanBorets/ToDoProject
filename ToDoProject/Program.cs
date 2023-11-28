using Microsoft.EntityFrameworkCore;
using ToDoProject.Common.Utilities;
using ToDoProject.Common.Utilities.Interfaces;
using ToDoProject.DAL;
using ToDoProject.DAL.Repository;
using ToDoProject.DAL.UnitOfWork;
using ToDoProject.Domain;
using ToDoProject.Services.Interfaces;
using ToDoProject.Services.Services;
using ToDoProject.Services.StartApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
    //options.UseLazyLoadingProxies(); Lazy loading
    options.EnableSensitiveDataLogging(false);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfileConfiguration());
});

builder.Services.AddSingleton(config.CreateMapper());

builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IHashUtility, HashUtility>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICardService, CardService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
