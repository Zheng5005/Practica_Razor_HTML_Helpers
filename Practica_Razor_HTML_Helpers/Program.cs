using Microsoft.EntityFrameworkCore;
using Practica_Razor_HTML_Helpers.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inyeccion
builder.Services.AddDbContext<equiposContext>(options =>
            options.UseSqlServer(
                    builder.Configuration.GetConnectionString("equiposDbConnection")
                )
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
