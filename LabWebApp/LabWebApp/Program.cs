using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LabWebApp.Data.ApplicationDbContext>(options => {
    options.UseSqlServer("Server=127.0.0.1;Database=ProductsDb;User=root;Password=123ABC@#;");
});


builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<LabWebApp.Data.ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddGitHub(o =>
    {
        o.ClientId = "591685383525d072a882";
        o.ClientSecret = "91c2da26d58ee0c50a085102479be487e594c65b";
        o.CallbackPath = "/signin-github";
        // Grants access to read a user's profile data.
        o.Scope.Add("read:user");
        // Optional: if you need an access token to call GitHub APIs
        o.Events.OnCreatingTicket += context =>
        {
            if (context.AccessToken is { })
            {
                context.Identity?.AddClaim(new Claim("access_token", context.AccessToken));
            }
            return Task.CompletedTask;
        };
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
