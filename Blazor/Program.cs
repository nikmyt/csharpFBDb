using Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;
//using BlazorServer.Hubs;
//using Blazor.Hubs; //good lord why
using Blazor.Server.Hubs; //?????


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
    //this crazy garbage makes able to use octet stream, whatever that is
});

var app = builder.Build();

app.UseResponseCompression(); //added

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub(); //both ways?
app.MapHub<ChatHub>("/chathub"); //added
app.MapFallbackToPage("/_Host");

app.Run();
