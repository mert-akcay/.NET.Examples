using Identity101.Data;
using Identity101.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var con1 = builder.Configuration.GetConnectionString("con1");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(con1));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
 {
     options.Password.RequireDigit = true;
     options.Password.RequireLowercase = false;
     options.Password.RequireUppercase = false;
     options.Password.RequireNonAlphanumeric = false;
     options.Password.RequiredLength = 6;
     options.Password.RequiredUniqueChars = 1;

     //user settings
     options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
     options.User.RequireUniqueEmail = true;
 }).AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
