using Examples;
using BuildingBlocks.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ExamplesModule.Install(builder);

builder.AddAssemblyServices(typeof(Program).Assembly);


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

app.UseAuthorization();

app.MapControllers();

app.MapEndpoints();

app.Run();
