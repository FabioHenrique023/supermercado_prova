using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(static opt =>
    {
        opt.LoginPath = new PathString("/Login/Index");
        opt.LogoutPath = new PathString("/Home/Logout");
        opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(120);

        opt.Cookie = new CookieBuilder(){
            HttpOnly = true,
            SameSite = SameSiteMode.Lax,
            Name = CookieAuthenticationDefaults.AuthenticationScheme,
            MaxAge = TimeSpan.FromMinutes(120),

        };
    });

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(options => 
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});

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

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();