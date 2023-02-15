using Microsoft.EntityFrameworkCore;
using SuppliersProject.Data;
using SuppliersProject.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options => options.UseMySql(
"server=localhost;database=suppliersproject; uid=root; pwd=muzambinho13; port=3307",
Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31")
));
builder.Services.AddScoped<SupplierService>();
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
