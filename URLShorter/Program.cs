using URLShorter.Infrastructure.Data;
using URLShorter.Infrastructure.ExceptionFilter;
using URLShorter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UrlService>();
builder.Services.AddScoped<ServiceLayerExceptionFilter>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options => options.Filters.Add<ServiceLayerExceptionFilter>());
builder.Services.AddDbContext<DatabaseContext>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();