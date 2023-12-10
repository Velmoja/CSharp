using ASP.NET;
using MaximTechnology;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration
builder.Configuration.Bind("AppSettings", new AppSettings());
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add RandomApiBoundaryProvider registration
builder.Services.AddSingleton<RandomApiBoundaryProvider>(provider =>
{
    var appSettings = provider.GetRequiredService<IOptions<AppSettings>>().Value;
    return new RandomApiBoundaryProvider(appSettings.RandomApi);
});

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