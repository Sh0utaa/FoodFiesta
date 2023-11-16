using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodFiesta.Data;
using FoodFiesta.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FoodFiestaDBContextConnection") ?? throw new InvalidOperationException("Connection string 'FoodFiestaDBContextConnection' not found.");

builder.Services.AddDbContext<FoodFiestaDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<FoodFiestaUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FoodFiestaDBContext>();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
