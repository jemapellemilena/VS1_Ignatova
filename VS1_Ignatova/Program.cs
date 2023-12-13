using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VS1_Ignatova.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppCtx>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppCtx>();

/*builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RoleInitializer", policy =>
          policy.RequireRole("admin", "registeredUser"));
});*/

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    RoleInitializer.InitializeAsync(userManager, rolesManager);
}

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
