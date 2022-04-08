using MVC101.Services.EmailService;
using MVC101.Services.SmsService;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISmsService ,WissenSmsService>();
builder.Services.AddSendGrid(options =>
{
    options.ApiKey = "API_KEY";
});
//builder.Services.AddScoped<IEmailService, OutlookEmailService>();
builder.Services.AddScoped<SendGridEmailService>()
    .AddScoped<IEmailService, SendGridEmailService>(s => s.GetService<SendGridEmailService>());
builder.Services.AddScoped<OutlookEmailService>()
    .AddScoped<IEmailService, OutlookEmailService>(s => s.GetService<OutlookEmailService>());

builder.Services.AddControllersWithViews();

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
