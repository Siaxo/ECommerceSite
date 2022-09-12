using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ECommerceSite.Models;
using ECommerceSite.Data;
using ECommerceSite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ECommerceDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})  // Add Account creation restrictions
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ECommerceDBContext>();

builder.Services.AddTransient<DataInitializer>();
builder.Services.AddTransient<IPageService, PageService>();
builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddTransient<ICartService, CartService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<DataInitializer>().SeedData();
}




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
