using AcademyF.TestWeek7.Core.BusinessLayer;
using AcademyF.TestWeek7.Core.Interfaces;
using AcademyF.TestWeek7.RepositoryEF;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configurazione DI//creo i collegamenti
builder.Services.AddScoped<IBusinessLayer, BusinessLayer>();
builder.Services.AddScoped<IRepositoryUser, RepositoryUserEF>();
builder.Services.AddScoped<IRepositoryDish, RepositoryDishEF>();
builder.Services.AddScoped<IRepositoryMenu, RepositoryMenuEF>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => { option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login"); option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/User/Forbidden"); });
builder.Services.AddAuthorization(options => options.AddPolicy("Adm", policy => policy.RequireRole("Administrator")));
builder.Services.AddAuthorization(options => options.AddPolicy("User", policy => policy.RequireRole("User")));

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
