using JobDescriptionGenerator.Components;
using Microsoft.EntityFrameworkCore;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton(sp =>
{
    var yaml = File.ReadAllText("Data/JobLevels.yaml");
    return new DeserializerBuilder()
        .WithNamingConvention(NullNamingConvention.Instance)
        .Build()
        .Deserialize<JobLevelDictionary>(yaml);
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=dev.db"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public class JobLevelDictionary : Dictionary<string, List<string>> { }
