using System.Reflection;
using Auction.Application.Behaviours;
using Auction.Application.Mediator;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var assemblies = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// builder.Services.AddMediatR(config =>
// {
//     config.AsScoped();
// }, assemblies);

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

var openGenericType = typeof(IValidator<>);
var types = assemblies
    .SelectMany(a => a
    .GetTypes()
    .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition));

foreach (var type in types)
{
    var validatorInterface = type
        .GetInterfaces()
        .FirstOrDefault(t => t.IsGenericType &&  t.GetGenericTypeDefinition() == openGenericType);

    if (validatorInterface is not null)
        builder.Services.AddSingleton(validatorInterface, type);
}

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
