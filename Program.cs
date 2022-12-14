using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OTP_Application.Data;
using OTP_Application.Helpers;
using OTP_Application.Interfaces;
using OTP_Application.Models;
using OTP_Application.Twilio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>(
    opt =>
    {
        opt.Password.RequiredLength = 7;
        opt.Password.RequireDigit = false;
        opt.Password.RequireUppercase = false;
        opt.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddTransient<ISMSServices, TwilioService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// migrate any database changes on startup (include initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
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
