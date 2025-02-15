using AutoMapper;
using CurrencyConverter.Domain.QueryHandlers;
using CurrencyConverter.Domain.Utilities;
using CurrencyConverter.Service.IoC;
using CurrencyConverter.Service.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<ServiceUrlOption>(builder.Configuration.GetSection(ServiceUrlOption.ConfigName));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
      .AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetCurrencyRateHistoryQueryHandler).Assembly));

builder.Services.AddMemoryCache();

// Auto Mapper Configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();

RegisterTypes(builder.Services);

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




/// <summary>
///
/// </summary>
/// <param name="services"></param>
void RegisterTypes(IServiceCollection services)
{
    services
        .RegisterServiceDataTypes();
}