using GG.Auction.Application;
using GG.Auction.Application.Behaviours;
using GG.Auction.Application.Mediator;
using GG.Auction.Database.Auction;
using GG.Auction.Database.Bet;
using GG.Auction.Database.Lot;
using GG.Auction.Domain;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var assemblies = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.AsScoped(), assemblies);
builder.Services.AddSingleton<IRepository<GG.Auction.Domain.Auction>, InMemoryAuctionsRepository>();
builder.Services.AddSingleton<IRepository<Bet>, InMemoryBetsRepository>();
builder.Services.AddSingleton<IRepository<Lot>, InMemoryLotsRepository>();
builder.Services.AddSingleton<UnitOfWork>();


var openGenericType = typeof(IValidator<>);
var types = assemblies
    .SelectMany(a => a
        .GetTypes()
        .Where(t => t is {IsAbstract: false, IsGenericTypeDefinition: false}));

foreach (var type in types)
{
    var validatorInterface = type
        .GetInterfaces()
        .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == openGenericType);
    
    if (validatorInterface is not null)
        builder.Services.AddSingleton(validatorInterface, type);
}

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
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
