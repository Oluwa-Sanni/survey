using IPS_survey.Context;
using IPS_survey.Repos;
using IPS_survey.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerManager();
// Add services to the container.
builder.Services.AddCors(
               options =>
               {
                   options.AddPolicy("EnableCORS", builder =>
                   {
                       builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                   });
               }
               );
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
               options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("IPS-survey"))
               );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ISurveyRepo, SurveyRepo>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<IIdentityAdapter, IdentityAdapter>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetRequiredSection(nameof(ApplicationSettings)));

builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("EmailConfig", c =>
{
    c.DefaultRequestHeaders.Clear();
    c.Timeout = TimeSpan.FromSeconds(60);
    c.BaseAddress = new Uri(builder.Configuration["ApplicationSettings:EmailAccount:EmailUrl"]!);
});
builder.Services.AddHttpClient("IdentityConfig", c =>
{
    c.DefaultRequestHeaders.Clear();
    c.Timeout = TimeSpan.FromSeconds(60);
    c.BaseAddress = new Uri(builder.Configuration["ApplicationSettings:EmailAccount:IdentityUrl"]!);
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMemoryCache();
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Create a scope to get an instance of the RoleManager
using var serviceScope = app.Services.CreateScope();


var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
logger.LogInfo($"Starting up auth application...");

try
{
    await dbContext.Database.MigrateAsync();
    //DbInitializer.Seed(dbContext);
}
catch (Exception ex)
{

    logger.LogError($"{ex}");
    logger.LogError($"Error on migrating application db: {ex.Message}");
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors("EnableCORS");
app.UseAuthorization();

app.MapControllers();

app.Run();
