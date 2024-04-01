using ExpenseManagement.DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBContextExpMgt>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseCnn")));
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
    pattern: "{controller=UserProfile}/{action=Login}/{id?}");

app.Run();
