using MyApp.Infrastructure.Persistence;
using MyAPP.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOpenApi();
builder.Services.ADDAllDI(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//app.MapGet("/db-test", async (AppDbContext db) =>
//{
//    var canConnect = await db.Database.CanConnectAsync();

//    return canConnect
//        ? "Database connection successful"
//        : "Database connection failed";
//});
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Swagger}/{action=Index}/{id?}");
app.Run();
