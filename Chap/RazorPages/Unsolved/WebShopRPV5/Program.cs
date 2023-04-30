
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => 
{
    // Add authorization options
    options.Conventions.AuthorizeFolder("/Products");
    options.Conventions.AuthorizeFolder("/Orders");
    options.Conventions.AuthorizeFolder("/Customers");
});

// Add data services
builder.Services.AddSingleton<IProductDataService, EFCProductDataService>();
builder.Services.AddSingleton<ICustomerDataService, EFCCustomerDataService>();
builder.Services.AddSingleton<IOrderDataService, EFCOrderDataService>();
builder.Services.AddSingleton<IUserDataService, EFCUserDataService>();

// Add statistics services
builder.Services.AddTransient<IProductStatisticsService, ProductStatisticsService>();
builder.Services.AddTransient<ICustomerStatisticsService, CustomerStatisticsService>();


// Add cookie-based Authentication
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/LogIn/LogInPage";
});


var app = builder.Build();

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
app.UseAuthentication(); // Enables cookie-based Authentication
app.UseAuthorization();

app.MapRazorPages();

app.Run();
