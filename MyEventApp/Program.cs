using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyEventApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    var RoleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var UserManager = services.GetRequiredService<UserManager<IdentityUser>>();
    string[] roleNames = { "PPAAdministrators", "PPAMembers" };
    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExist = await RoleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            //create the roles and seed them to the database: Question 1
            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
    //Here you could create a super user who will maintain the web app
    var poweruser = new IdentityUser
    {
        UserName = "Administrator@gmail.com",
        Email = "Administrator@gmail.com",
        EmailConfirmed = true,
    };
    //Ensure you have these values in your appsettings.json file
    string userPWD = "Abc@123456";
    var _user = await UserManager.FindByEmailAsync("Administrator@gmail.com");

    if (_user == null)
    {
        var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
        if (createPowerUser.Succeeded)
        {
            //here we tie the new user to the role
            await UserManager.AddToRoleAsync(poweruser, "PPAAdministrators");
        }
    }
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();