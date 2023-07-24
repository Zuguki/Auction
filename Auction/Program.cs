using Auction.Application;
using ChangeCreationStateAuctionCommand.Application;
using ChangeCreationStateAuctionCommand.Application.Behaviours;
using ChangeCreationStateAuctionCommand.Application.Mediator;
using ChangeCreationStateAuctionCommand.Database.Auction;
using ChangeCreationStateAuctionCommand.Database.Bet;
using ChangeCreationStateAuctionCommand.Database.Lot;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var assemblies = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.AsScoped(), assemblies);
builder.Services.AddSingleton<IRepository<ChangeCreationStateAuctionCommand.Domain.Auction>, InMemoryAuctionsRepository>();
builder.Services.AddSingleton<IRepository<ChangeCreationStateAuctionCommand.Domain.Bet>, InMemoryBetsRepository>();
builder.Services.AddSingleton<IRepository<ChangeCreationStateAuctionCommand.Domain.Lot>, InMemoryLotsRepository>();
builder.Services.AddSingleton<UnitOfWork>();


var openGenericType = typeof(IValidator<>);
var types = assemblies
    .SelectMany(a => a
        .GetTypes()
        .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition));

foreach (var type in types)
{
    var validatorInterface = type
        .GetInterfaces()
        .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == openGenericType);
    
    if (validatorInterface != null)
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
