using ASP.NET;
using MaximTechnology;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
int parallelLimit = builder.Configuration.GetValue<int>("AppSettings:Settings:ParallelLimit", 10);
var semaphore = new SemaphoreSlim(parallelLimit);

builder.Services.AddSingleton(semaphore);
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

// Counter for current requests
int currentRequests = 0;
object lockObject = new object();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    var sem = context.RequestServices.GetRequiredService<SemaphoreSlim>();

    lock (lockObject)
    {
        if (currentRequests >= parallelLimit)
        {
            context.Response.StatusCode = 503;
            context.Response.WriteAsync("HTTP ошибку 503 Service Unavailable. Service Unavailable.");
            return;
        }

        currentRequests++;
    }

    try
    {
        await next();
    }
    finally
    {
        lock (lockObject)
        {
            currentRequests--;
        }
    }
});

app.MapControllers();

app.Run();
