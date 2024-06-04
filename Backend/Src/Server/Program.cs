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

builder.Services.AddCors();

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

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.MapControllers();

app.Run();