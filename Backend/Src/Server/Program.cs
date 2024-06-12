var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var kestrelSection = configuration.GetSection("Kestrel");
    serverOptions.Configure(kestrelSection);
}).UseKestrel();

builder.Services.AddDatabase(configuration);

builder.Services.AddHelpers();
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddJwtAuthentication(configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwagger();
builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()));     

var app = builder.Build();

#if DEBUG
app.AddSwagger();
#endif

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Files")),
    RequestPath = "/Files"
});


app.UseAuthentication();
app.UseAuthorization();


// ********************
// USE CORS - might not be required.
// ********************
app.UseCors("AllowAll");

app.MapControllers();

app.Run();