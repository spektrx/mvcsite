using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using mvcsite.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

string connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();
builder.Services.AddAuthentication("Cookies").AddCookie(options => options.LoginPath = "/Account/Login");
builder.Services.AddAuthorization();

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
/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HelloWorld}/{action=Index}/{id?}");*/
app.Run();

