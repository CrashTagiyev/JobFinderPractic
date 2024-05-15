using JobFinderPractic.DataAccess.Data;
using JobFinderPractic.Domain.Entities.Abstracts;
using JobFinderPractic.Registers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// My All Service
builder.Services.AddDbContextServices();
builder.Services.AddRepositoryServices();
builder.Services.AddIdentityConfigureServices();

builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
//Cookie options

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	 name: "areas",
	 pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
   );

	endpoints.MapControllerRoute(
		 name: "default",
			  pattern: "{controller=Home}/{action=Index}/{id?}");

	endpoints.MapDefaultControllerRoute();
});
#pragma warning restore ASP0014



//Creating Employer and Admin role and Admin account

using var container = app.Services.CreateScope();
var usermanager = container.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
var roleManager = container.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


var employerRole = await roleManager.RoleExistsAsync("Employer");
if (!employerRole)
	await roleManager.CreateAsync(new IdentityRole("Employer"));

var employeeRole = await roleManager.RoleExistsAsync("Employee");
if (!employeeRole)
	await roleManager.CreateAsync(new IdentityRole("Employee"));



app.Run();
