using EcommerceAPI.Filters;
using EcommerceAPI.Middlewares;
using EcommerceAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// How to add a Filter
// builder.Services.AddControllers(options =>
// {
//     options.Filters.Add<StatsFilter>();
// });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<TimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Class Middleware
// app.UseMiddleware<StatsMiddleware>();

/* Inline Middleware
app.Use((context, next) =>
{
    DateTime requestTime = DateTime.Now;
    var result = next(context);

    DateTime responseTime = DateTime.Now;
    TimeSpan processDuration = responseTime - requestTime;

    Console.WriteLine("[Inline Middleware] Process Duration=" + processDuration.TotalMilliseconds + "ms");
    return result;
});
*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
