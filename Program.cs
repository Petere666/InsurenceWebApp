using InsurenceWebApp;
using InsurenceWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 8;
        options.SignIn.RequireConfirmedAccount = false; //for development is off, makeing problems with register new client without email servis what will send confirmation email
        options.User.RequireUniqueEmail = true;         //its necessary to program working right
        options.Password.RequireNonAlphanumeric = false; //for development is off..
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

using (IServiceScope scope = app.Services.CreateScope())
{
    RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    IdentityUser? defaultAdminUser = await userManager.FindByEmailAsync("Admin@Admin.cz"); // Admin@Admin.cz Password: HesloAdmina111

    if (!await roleManager.RoleExistsAsync(UsersRoler.Admin))
        await roleManager.CreateAsync(new IdentityRole(UsersRoler.Admin));

    if (defaultAdminUser is not null && !await userManager.IsInRoleAsync(defaultAdminUser, UsersRoler.Admin))
        await userManager.AddToRoleAsync(defaultAdminUser, UsersRoler.Admin);
}

app.Run();


