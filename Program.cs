using System.Text.Json;
using JobDescriptionGenerator.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var json = File.ReadAllText("Data/JobLevels.json");
var jobLevels = JsonSerializer.Deserialize<JobLevelDictionary>(json)!;

builder.Services.AddSingleton(jobLevels);
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

public class JobLevelDictionary : Dictionary<string, string> { }
