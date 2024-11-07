using HealthDataApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using HealthDataApp.Services.Interface;
using HealthDataApp.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IHealthDataService, HealthDataService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IPatientService, PatientService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
