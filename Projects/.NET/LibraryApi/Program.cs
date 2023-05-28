using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(""));
builder.Services.AddMediatR(typeof(ProjectAssemblyEntryPoint).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(ProjectAssemblyEntryPoint).Assembly);
builder.Services.AddLogging();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(IValidationBehavior<,>));
builder.Services.AddTransient(typeof(IValidationContext), typeof(ValidationContext<>));

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
