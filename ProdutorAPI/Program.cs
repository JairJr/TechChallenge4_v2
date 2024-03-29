using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Adding MassTransit with Azure Service Bus
builder.Services.AddMassTransit(definicoesGerais =>
{
    definicoesGerais.UsingAzureServiceBus((contexto, configuracoesServiceBus) =>
    {
        configuracoesServiceBus.Host(builder.Configuration.GetConnectionString("ServiceBusConnectionString"));
    });
});

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

app.Run();
