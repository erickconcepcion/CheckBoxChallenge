using CheckboxChallenge.Domains;
using CheckboxChallenge.Services;
using CheckboxChallenge.Domains.Implementations;
using CheckboxChallenge.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IOperatorService, AddOperatorService>();
builder.Services.AddScoped<IOperatorService, MinusOperatorService>();
builder.Services.AddScoped<IOperatorService, MultiplyOperatorService>();
builder.Services.AddScoped<IOperatorService, DivideOperatorService>();
builder.Services.AddScoped<IOperationDomain, OperationDomain>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
