using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Studentregistration.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<StudentDbcontext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("benconnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StudentDbcontext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Accounts/loging";
}
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
