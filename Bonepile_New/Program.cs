using Bonepile_New.Data;
using Bonepile_New.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
//builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<BonepileService>();
builder.Services.AddScoped<HardRepairService>();
builder.Services.AddScoped<Armario_BoneService>();
//builder.Services.AddHttpClient<BonepileChartService>();
builder.Services.AddScoped<BonepileChartService>();
builder.Services.AddScoped<HistoryService>();
builder.Services.AddHttpClient();
builder.Services.AddMatBlazor();


builder.Services.AddDbContext<BancoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});

builder.Services.AddDbContext<BancoContext1>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1"),
    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
//app.MapControllers();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
});


app.Run();
