using BlazorMinimalApiHtmx.Components;
using BlazorMinimalApiHtmx.HtmlApi;
using Microsoft.AspNetCore.Components.Web;
using HypermediaEndpoints = BlazorMinimalApiHtmx.HtmlApi.Endpoints;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

// Add the renderer and wrapper to services
builder.Services.AddScoped<HtmlRenderer>();
builder.Services.AddScoped<BlazorRenderer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();
HypermediaEndpoints.Map(app);

app.Run();
