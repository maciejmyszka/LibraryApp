using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LibraryAppContextConnection");

builder.Services.AddDbContext<LibraryAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LibraryAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryAppContext>();

// Add services to the container.
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

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Employee", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        };
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<LibraryAppUser>>();

    string email = "admin@admin.com";
    string password = "Admin123!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new LibraryAppUser();
        user.FirstName = "Maciej";
        user.LastName = "Myszka";
        user.Email = email;
        user.UserName = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }

    string employeeEmail = "employee@employee.com";
    string employeePassword = "Employee123!";

    if (await userManager.FindByEmailAsync(employeeEmail) == null)
    {
        var user = new LibraryAppUser();
        user.FirstName = "Jan";
        user.LastName = "Nowak";
        user.Email = employeeEmail;
        user.UserName = employeeEmail;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, employeePassword);
        await userManager.AddToRoleAsync(user, "Employee");
    }
}

app.Run();
